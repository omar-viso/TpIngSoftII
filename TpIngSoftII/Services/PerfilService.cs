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
    public class PerfilService : EntityAppServiceBase<Perfil, PerfilDto>, IPerfilService
    {

        public PerfilService(IEntityBaseRepository<Perfil> entityRepository, IUnitOfWork unitOfWork, IAppContext appContext) : base(entityRepository, unitOfWork, appContext)
        {
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Perfil entity, PerfilDto dto, bool isNew)
        {
            if (dto.ValorHorario <= 0) throw new System.ArgumentException("El valor de las horas es obligatorio y tiene que ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(dto.Descripcion)) throw new System.ArgumentException("La descripcion del perfil es obligatoria");           
        }
    }
}
