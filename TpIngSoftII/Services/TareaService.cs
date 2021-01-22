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
    public class TareaService : EntityAppServiceBase<Tarea, TareaDto>, ITareaService
    {
        private readonly IEntityBaseRepository<Empleado> empleadoRepository;

        public TareaService(IEntityBaseRepository<Tarea> entityRepository, IUnitOfWork unitOfWork, IAppContext appContext, IEntityBaseRepository<Empleado> empleadoRepository) : base(entityRepository, unitOfWork, appContext)
        {
            this.empleadoRepository = empleadoRepository;
        }

        protected override void ValidarEntityUpdating(Tarea entity, TareaDto dto, bool isNew)
        {
            //obtengo el proyecto de esta tarea en particular para ese empleado //CORREGIR ESTO
            //var proyecto = proyectoRepository.AllIncludingAsNoTracking(x => x.Tareas).Select(y => y.ID == dto.ProyectoID);
            var tarea = entityRepository.AllIncludingAsNoTracking(x => x.EmpleadoPerfil)
                                        .FirstOrDefault(x => x.ProyectoID == dto.ProyectoID 
                                                             && x.EmpleadoPerfil.EmpleadoID == /* EmpleadoID */);
            // Buscar EmpleadoID en Perfiles y comparar para traer tarea en base a ese EmpleadoID

        }
    }
}
