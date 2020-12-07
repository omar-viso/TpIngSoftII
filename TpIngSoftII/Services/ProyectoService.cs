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
    public class ProyectoService : EntityAppServiceBase<Proyecto, ProyectoDto>, IProyectoService
    {
        private readonly IEntityBaseRepository<HorasTrabajadas> horasTrabajadasRepository;


        public ProyectoService(IEntityBaseRepository<Proyecto> entityRepository, IUnitOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
        }

        public decimal HorasTrabajadasPorProyecto(int proyectoID)
        {
            var proyectoTemp = this.entityRepository.AllIncluding().Where(x => x.ID == proyectoID);
            if (proyectoTemp == null)
            {
               throw new Exception("No existe proyecto para el id indicado");
            }
            var horasTrabajadasProyecto = this.horasTrabajadasRepository.All.Where(x => x.ProyectoID == proyectoID);
            decimal totalHorasTrabajadas=0;
            if (horasTrabajadasProyecto.Any())
            {
                foreach(var hsProyecto in horasTrabajadasProyecto)
                {
                    totalHorasTrabajadas += hsProyecto.CantHoras;
                }
            }
            return totalHorasTrabajadas;
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */

    }
}
