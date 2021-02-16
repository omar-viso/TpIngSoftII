using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class EmpleadoService : EntityAppServiceBase<Empleado, EmpleadoDto>, IEmpleadoService
    {
        public EmpleadoService(IEntityBaseRepository<Empleado> entityRepository, 
                               IUnitOfWork unitOfWork, 
                               IAppContext appContext) : base(entityRepository, unitOfWork, appContext)
        {
        }


        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Empleado entity, EmpleadoDto dto, bool isNew)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre)) throw new System.ArgumentException("El Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Apellido)) throw new System.ArgumentException("El Apellido es obligatorio.");
            if (dto.Dni <= 0) throw new System.ArgumentException("El DNI indicado no es válido.");
            if (dto.FechaIngreso == null || dto.FechaIngreso == DateTime.MinValue) throw new System.ArgumentException("La Fecha de Ingreso es obligatoria.");
            if (string.IsNullOrWhiteSpace(dto.Usuario)) throw new System.ArgumentException("El Usuario es obligatorio.");
            if (this.ValidarUsuarioExistente(dto)) throw new System.ArgumentException("El Usuario indicado ya se encuentra en uso. Intente con otro nuevamente.");
            if (string.IsNullOrWhiteSpace(dto.Clave)) throw new System.ArgumentException("La Clave es obligatoria.");
            /* Validaciones sobre Perfiles */
            if (dto.Perfiles != null)
            {
                if (dto.Perfiles.Count > 0)
                {

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

        public decimal Antiguedad(int empleadoID)
        {
            decimal antiguedad = 0;
            var empleadoTemp = this.entityRepository.AllIncludingAsNoTracking().Where(x => x.ID == empleadoID);
            if (empleadoTemp.Any())
            {
               var empleadoTmp = empleadoTemp.FirstOrDefault();
                antiguedad = DateTime.Today.Year - empleadoTmp.FechaIngreso.Year;
            }
            return antiguedad;
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

        private bool ValidarUsuarioExistente(EmpleadoDto dto)
        {
            bool resultado = false;
            /* Se busca si existe un Empleado con el Usuario ingresado en el dto */
            var entity = this.entityRepository.AllIncludingAsNoTracking()
                                              .FirstOrDefault(x => x.Usuario == dto.Usuario);
            /* Si no se encuentra, se puede utilizar dicho Usuario */
            if (entity == null) resultado = false;
            /* Si se encuentra resultado y coinciden los IDs, el usuario es el mismo por lo tanto no hay problema */
            else if (entity?.ID == dto.ID) resultado = false;
            /* Si no ocurre ninguna de las 2 anteriores, es porque ya se esta utilizando por otro Empleado dicho Usuario */
            else resultado = true;

            return resultado;
        }
    }
}
