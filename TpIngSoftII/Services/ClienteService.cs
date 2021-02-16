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
            /* Validaciones si es una Persona Fisica */
            if (string.IsNullOrWhiteSpace(dto.Nombre)) throw new System.ArgumentException("El Nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(dto.Apellido)) throw new System.ArgumentException("El Apellido es obligatorio.");
            /* Validaciones si es una Persona Juridica */
            if (string.IsNullOrWhiteSpace(dto.RazonSocial)) throw new System.ArgumentException("La Razon Social es obligatoria.");

            if (string.IsNullOrWhiteSpace(dto.Direccion)) throw new System.ArgumentException("La Dirección es obligatoria.");
            if (dto.DniCuit == 0) throw new System.ArgumentException("El DNI/CUIT es obligatorio.");
            if (dto.DniCuit < 0) throw new System.ArgumentException("El DNI/CUIT indicado no es válido.");
            if ((dto.TelefonoContacto ?? 0) < 0) throw new System.ArgumentException("El Telefono de Contacto indicado no es válido.");
        }
    }
}
