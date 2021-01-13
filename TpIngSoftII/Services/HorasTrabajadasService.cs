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
        private readonly IEntityBaseRepository<Tarea> tareaRepository;

        public HorasTrabajadasService(IEntityBaseRepository<HorasTrabajadas> entityRepository, 
                                      IUnitOfWork unitOfWork,
                                      IEntityBaseRepository<Tarea> tareaRepository) : base(entityRepository, unitOfWork)
        {
            this.tareaRepository = tareaRepository;
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(HorasTrabajadas entity, HorasTrabajadasDto dto, bool isNew)
        {
            if (dto.CantHoras<0) throw new System.ArgumentException("La cantidad de horas no puede ser negativo");
            if (dto.Fecha == null || dto.Fecha == DateTime.MinValue) throw new System.ArgumentException("La Fecha es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.ProyectoID.ToString())) throw new System.ArgumentException("El id de proyecto es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.TareaID.ToString())) throw new System.ArgumentException("La id de tarea es obligatoria");
            if (string.IsNullOrWhiteSpace(dto.HorasTrabajadasEstadoID.ToString())) throw new System.ArgumentException("La id del estado de horas trabajadas es obligatoria");


            this.LogicaCantidadHorasTarea(dto);
        }

        void LogicaCantidadHorasTarea(HorasTrabajadasDto dto)
        {
            var hsTotalesTarea = this.entityRepository.AllIncludingAsNoTracking()
                                                      .Where(x => x.TareaID == dto.TareaID)
                                                      .Sum(x => x.CantHoras);
            var tarea = this.tareaRepository.AllIncludingAsNoTracking().FirstOrDefault(x => x.ID == dto.TareaID);
            var hsEstimadas = tarea.HorasEstimadas;

            var hayHsOB = dto.CantHoras + hsTotalesTarea > hsEstimadas;

            // VER COMO AGREGAR ALERTAR CUANDO SE ESTAN POR CARGAR HS OB
            if (hayHsOB)
            {
                decimal hsOBACargar = 0;
                decimal hsNoOBACargar = 0;
                /* Si ya se superaron las hs totales a las estimadas, las hs a cargar son todas OB */
                if (hsTotalesTarea > hsEstimadas)
                {
                    hsOBACargar = dto.CantHoras;
                    hsNoOBACargar = 0;
                }
                else
                {
                    hsOBACargar = dto.CantHoras + hsTotalesTarea - hsEstimadas;
                    hsNoOBACargar = dto.CantHoras - hsOBACargar;
                }

                // HACER OVERRIDE DEL UPDATE PARA MODIFICAR LA CANTIDAD DE HS A CARGAR
                // EN PPIO. SE HARIA EL UPDATE PONIENDO LAS CANTHS NO OB Y VER EL CASO CUANDO HAY OB
            }

        }
    }
}
