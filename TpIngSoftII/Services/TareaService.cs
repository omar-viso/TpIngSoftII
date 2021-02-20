using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.Constantes;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class TareaService : EntityAppServiceBase<Tarea, TareaDto>, ITareaService
    {
        private readonly IEntityBaseRepository<EmpleadoPerfil> empleadoPerfilRepository;
        private readonly IEntityBaseRepository<Proyecto> proyectoRepository;
        public TareaService(IEntityBaseRepository<Tarea> entityRepository, 
                            IUnitOfWork unitOfWork, IAppContext appContext, 
                            IEntityBaseRepository<EmpleadoPerfil> empleadoPerfilRepository,
                            IEntityBaseRepository<Proyecto> proyectoRepository) : base(entityRepository, unitOfWork, appContext)
        {
            this.empleadoPerfilRepository = empleadoPerfilRepository;
            this.proyectoRepository = proyectoRepository;
        }

        public List<TareaDto> GetTareasEmpleado(int empleadoID)
        {
            var tareasEmpleados = entityRepository.AllIncludingAsNoTracking(x => x.EmpleadoPerfil,
                                                                            x => x.EmpleadoPerfil.Empleado)
                                                                            .Where(x => x.EmpleadoPerfil.EmpleadoID == empleadoID)
                                                                            .ToList();
            return Mapper.Map<List<Tarea>, List<TareaDto>>(tareasEmpleados);
        }

        protected override void ValidarEntityUpdating(Tarea entity, TareaDto dto, bool isNew)
        {
            if (proyectoRepository.GetSingle(dto.ProyectoID).ProyectoEstadoID != Const.ProyectoEstado.Vigente) throw new System.ArgumentException("El proyecto que intenta referenciar no se haya vigente.");

            if (dto.EmpleadoPerfilID <= 0) throw new System.ArgumentException("El Empleado-Perfil indicado no existe.");
            /* Se busca el id del Empleado indicado por el dto */
            var empleadoID = this.empleadoPerfilRepository.AllIncludingAsNoTracking()
                                                    .FirstOrDefault(x => x.ID == dto.ID)?.EmpleadoID ?? 0;
            //se busca si existe alguna tarea para el proyecto indicado que pertenezca al empleado */
            var tarea = entityRepository.AllIncludingAsNoTracking(x => x.EmpleadoPerfil)
                                        .FirstOrDefault(x => x.ProyectoID == dto.ProyectoID 
                                                          && x.EmpleadoPerfil.EmpleadoID == empleadoID);
            /* Si existe almenos una tarea para dicho Empleado en ese Proyecto, no se permite asignar otra */
            if (tarea != null) throw new System.ArgumentException("El Empleado indicado ya posee una tarea asignada en dicho Proyecto.");
        }

        
    }
}
