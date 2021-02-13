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
    public class ClienteService : EntityAppServiceBase<Cliente, ClienteDto>, IClienteService
    {
        public ClienteService(IEntityBaseRepository<Cliente> entityRepository, 
                               IUnitOfWork unitOfWork, 
                               IAppContext appContext) : base(entityRepository, unitOfWork, appContext)
        {
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Cliente entity, ClienteDto dto, bool isNew)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre)) throw new System.ArgumentException("El Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Apellido)) throw new System.ArgumentException("El Apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Direccion)) throw new System.ArgumentException("La Dirección es obligatoria.");
            if (dto.Dni == 0) throw new System.ArgumentException("El DNI es obligatorio.");
            if (dto.Dni < 0) throw new System.ArgumentException("El DNI indicado no es válido.");
            if (string.IsNullOrWhiteSpace(dto.RazonSocial)) throw new System.ArgumentException("La Razon Social es obligatoria.");
            if ((dto.TelefonoCelular ?? 0) < 0) throw new System.ArgumentException("El Telefono Celular indicado no es válido.");
            if ((dto.TelefonoFijo ?? 0) < 0) throw new System.ArgumentException("El Telefono Fijo indicado no es válido.");

        }
    }
}
