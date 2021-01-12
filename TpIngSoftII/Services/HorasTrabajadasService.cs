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
    public class HorasTrabajadasService : EntityAppServiceBase<HorasTrabajadas, HorasTrabajadasDto>, IHorasTrabajadasService
    {

        public HorasTrabajadasService(IEntityBaseRepository<HorasTrabajadas> entityRepository, IUnitOfWork unitOfWork, IAppContext appContext) : base(entityRepository, unitOfWork, appContext)
        {
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(HorasTrabajadas entity, HorasTrabajadasDto dto, bool isNew)
        {
            if (dto.CantHoras<0) throw new System.ArgumentException("La cantidad de horas no puede ser negativo");
            if (dto.Fecha == null || dto.Fecha == DateTime.MinValue) throw new System.ArgumentException("La Fecha es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.ProyectoID.ToString())) throw new System.ArgumentException("El id de proyecto es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.TareaID.ToString())) throw new System.ArgumentException("La id de tarea es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.HorasTrabajadasEstadoID.ToString())) throw new System.ArgumentException("La id del estado de horas trabajadas es obligatoria");
        }
    }
}
