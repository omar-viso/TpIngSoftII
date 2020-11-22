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

        public PerfilService(IEntityBaseRepository<Perfil> entityRepository, IUnitOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Perfil entity, PerfilDto dto, bool isNew)
        {
            if (string.IsNullOrWhiteSpace(dto.PerfilTipoID.ToString())) throw new System.ArgumentException("El tipo de perfil es obligatorio");
            if (string.IsNullOrWhiteSpace(dto.ValorHorario.ToString()) || dto.ValorHorario<0) throw new System.ArgumentException("El valor es obligatorio y debe ser mayor a 0");
            if (string.IsNullOrWhiteSpace(dto.PerfilTipoDescripcion)) throw new System.ArgumentException("La descripcion del perfil es obligatoria");

            
        }
    }
}
