using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using TpIngSoftII.Reportes;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class EmpleadoService : EntityAppServiceBase<Empleado, EmpleadoDto>, IEmpleadoService
    {
        private readonly IEntityBaseRepository<EmpleadoPerfil> empleadoPerfilRepository;
        private readonly IEntityBaseRepository<Perfil> perfilRepository;
        private readonly ISevice service;

        public EmpleadoService(IEntityBaseRepository<Empleado> entityRepository, 
                               IUnitOfWork unitOfWork, 
                               IAppContext appContext,
                               IEntityBaseRepository<EmpleadoPerfil> empleadoPerfilRepository,
                               IEntityBaseRepository<Perfil> perfilRepository,
                               ISevice service) : base(entityRepository, unitOfWork, appContext)
        {
            this.empleadoPerfilRepository = empleadoPerfilRepository;
            this.perfilRepository = perfilRepository;
            this.service = service;
        }


        public override EmpleadoDto Update(EmpleadoDto dto)
        {
            using (var scope = new TransactionScope())
            {
                Empleado entity = null;
                var isNew = (dto.ID == 0);

                this.ValidarEntityUpdating(entity, dto, isNew);

                if (dto.ID == 0)
                {
                    entity = Mapper.Map<EmpleadoDto, Empleado>(dto);
                    this.entityRepository.Add(entity);
                }
                else
                {
                    entity = this.entityRepository.GetSingle(dto.ID);
                    entity.Nombre = dto.Nombre;
                    entity.Apellido = dto.Apellido;
                    entity.Usuario = dto.Usuario;
                    entity.Clave = dto.Clave;
                    entity.Dni = dto.Dni;
                    entity.FechaIngreso = dto.FechaIngreso;
                    entity.RolID = dto.RolID;

                    UpdateDetallePerfiles(entity, dto);

                    this.entityRepository.Edit(entity);
                }

                this.unitOfWork.Commit();

                if (entity != null)
                {
                    dto.ID = entity.ID;
                    dto = Mapper.Map<Empleado, EmpleadoDto>(entity);
                }

                this.ValidarEntityUpdated(entity, dto, isNew);

                scope.Complete();
            }

            return dto;
        }

        private void UpdateDetallePerfiles(Empleado entityDb, EmpleadoDto dto)
        {
            //1. eliminar los que no vienen en el dto 
            var deletedItems = entityDb.Perfiles
                                       .Where(x => !dto.Perfiles.Any(r => r.ID == x.ID)).ToList();

            foreach (var item in deletedItems) { this.empleadoPerfilRepository.Delete(item); }

            //2. los que vienen con id los busco para modificar 
            foreach (var item in dto.Perfiles)
            {
                /*Concidera nuevo o no en función al ID, esto podría tener otras variantes 
                     a. Conciderar en función del ID 
                     b. Conciderar en función a otro indice primario*/
                if (item.ID != 0)
                {
                    //modificado 
                    var itemDb = entityDb.Perfiles.FirstOrDefault(x => x.ID == item.ID);
                    if (itemDb == null) throw new System.Exception("El item que intenta modificar no existe o fue eliminado.");

                    itemDb.PerfilID = item.PerfilID;
                }
                else
                {
                    //nuevo 
                    entityDb.Perfiles.Add(new EmpleadoPerfil
                    {
                        PerfilID = item.PerfilID
                    });
                }
            }
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Empleado entity, EmpleadoDto dto, bool isNew)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre)) throw new System.ArgumentException("El Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Apellido)) throw new System.ArgumentException("El Apellido es obligatorio.");
            if (!(9999999 < dto.Dni && dto.Dni < 100000000)) throw new System.ArgumentException("El DNI indicado no es válido.");
            if (dto.FechaIngreso == null || dto.FechaIngreso == DateTime.MinValue) throw new System.ArgumentException("La Fecha de Ingreso es obligatoria.");
            if (string.IsNullOrWhiteSpace(dto.Usuario)) throw new System.ArgumentException("El Usuario es obligatorio.");
            if (this.ValidarUsuarioExistente(dto)) throw new System.ArgumentException("El Usuario indicado ya se encuentra en uso. Intente con otro nuevamente.");
            if (string.IsNullOrWhiteSpace(dto.Clave)) throw new System.ArgumentException("La Clave es obligatoria.");
            /* Validaciones sobre Perfiles */
            if (dto.Perfiles != null)
            {
                if (dto.Perfiles.Count > 0)
                {
                    if (this.ValidarExistenciaPerfiles(dto)) throw new System.ArgumentException("Uno o más perfil/es indicado/s no son válido/s.");
                }
            }
        }

        public int ValidarCredenciales(LoginRequest login)
        {
            var credencialEncontrada = this.entityRepository.AllIncludingAsNoTracking().FirstOrDefault(x => x.Usuario == login.Username
                                                                                                 && x.Clave == login.Password);
            /* Devuelve id si lo encontro al usuario sino 0 */
            var usuarioId = credencialEncontrada?.ID ?? 0;

            return usuarioId;
        }

        public int Antiguedad(int empleadoID)
        {
            TimeSpan antiguedad;
            int antiguedadAños = 0;
            var empleadoTemp = this.entityRepository.AllIncludingAsNoTracking().Where(x => x.ID == empleadoID);
            if (empleadoTemp.Any())
            {
               var empleadoTmp = empleadoTemp.FirstOrDefault();
                //antiguedad = DateTime.Today.Year - empleadoTmp.FechaIngreso.Year;
                antiguedad = DateTime.Now.Date - empleadoTmp.FechaIngreso.Date;
                antiguedadAños = (int)(antiguedad.TotalDays / 365.25);
            }


            return antiguedadAños;
        }

        public EmpleadoDto DameMisDatos()
        {
            return this.GetById(this.appContext.EmpleadoID);
        }

        public int GetEmpleadoUsuarioPassword(string nombreUsuario, string passwordUsuario)
        {   /* Devuelve id del usuario si lo encuentro, 0 si NO */
            return (this.entityRepository.AllIncludingAsNoTracking()
                                           .FirstOrDefault(x => x.Usuario == nombreUsuario
                                                                && x.Clave == passwordUsuario))?.ID ?? 0;
        }


        public IEnumerable<PerfilDto> GetPerfilesDeEmpleado(int empleadoID)
        {
            var entity = empleadoPerfilRepository.AllIncludingAsNoTracking(x => x.Perfil)
                                                 .Where(x => x.EmpleadoID == empleadoID).Select(x => x.Perfil);

            var perfilesDto = Mapper.Map<IEnumerable<Perfil>, IEnumerable<PerfilDto>>(entity);

            return perfilesDto;
        }

        public IEnumerable<EmpleadoDto> GetEmpleadosDePerfil(int perfilID)
        {
            var entity = empleadoPerfilRepository.AllIncludingAsNoTracking(x => x.Empleado)
                                     .Where(x => x.PerfilID == perfilID).Select(x => x.Empleado);

            var empleadosDto = Mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoDto>>(entity);

            return empleadosDto;
        }


        public int GetEmpleadoPerfilID(int empleadoID, int perfilID)
        {
            var empleadoPerfil = empleadoPerfilRepository.AllIncludingAsNoTracking()
                                     .Where(x => x.EmpleadoID == empleadoID && 
                                                 x.PerfilID == perfilID).FirstOrDefault();
            return (empleadoPerfil?.ID ?? 0);
        }

        public EmpleadoPerfilDto GetEmpleadoPerfil(int empleadoPerfilID)
        {
            var empleadoPerfil = empleadoPerfilRepository.AllIncludingAsNoTracking()
                                     .Where(x => x.ID == empleadoPerfilID).FirstOrDefault();
            EmpleadoPerfilDto empleadoPerfilDto = null;
            if (empleadoPerfil != null)
            {
                empleadoPerfilDto = Mapper.Map<EmpleadoPerfil, EmpleadoPerfilDto>(empleadoPerfil);
            }
            return empleadoPerfilDto;
        }




        private bool ValidarUsuarioExistente(EmpleadoDto dto)
        {
            bool resultado = false;
            /* Se busca si existe un Empleado con el Usuario ingresado en el dto */
            var entity = this.entityRepository.AllIncludingAsNoTracking()
                                              .ToList()
                                              .FirstOrDefault(x => x.Usuario == dto.Usuario);
            /* Si no se encuentra, se puede utilizar dicho Usuario */
            if (entity == null) resultado = false;
            /* Si se encuentra resultado y coinciden los IDs, el usuario es el mismo por lo tanto no hay problema */
            else if (entity?.ID == dto.ID) resultado = false;
            /* Si no ocurre ninguna de las 2 anteriores, es porque ya se esta utilizando por otro Empleado dicho Usuario */
            else resultado = true;

            return resultado;
        }

        private bool ValidarExistenciaPerfiles(EmpleadoDto dto)
        {
            var perfilesExistentesIds = this.perfilRepository.AllIncludingAsNoTracking().Select(x => x.ID);

            var perfilesIds = dto.Perfiles.Select(x => x.PerfilID);
            var rta = !perfilesIds.All(x => perfilesExistentesIds.Contains(x));
            return rta;
        }

        public Stream EmpleadosReporte()
        {
            var EmpleadosDto = Mapper.Map<IEnumerable<Empleado>, IEnumerable<EmpleadoDto>>(this.entityRepository.AllIncludingAsNoTracking()).Select(x => new EmpleadoPdfDto
            {
                ID = x.ID,
                Nombre = x.Nombre ?? " - ",
                Dni = x.Dni,
                Apellido = x.Apellido ?? " - ",
                RolDescripcion = x.RolDescripcion ?? " - ",
                Usuario = x.Usuario ?? " - ",
                FechaIngreso = x.FechaIngreso.Date
            })?.OrderBy(x => x.Nombre)?.ThenBy(y => y.Apellido)
               .ToList();
            if (EmpleadosDto.Count() != 0)
            {
                using (var report = new Reportes.PDF.CrystalReportEmpleados())
                {
                    return this.service.GetReportPDF(report, EmpleadosDto);
                }
            }
            return null;
        }
    }
}
