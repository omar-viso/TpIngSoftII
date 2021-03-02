using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.Constantes;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using TpIngSoftII.Reportes;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class ClienteService : EntityAppServiceBase<Cliente, ClienteDto>, IClienteService
    {
        private readonly IReporteService reporteService;
        private readonly ISevice service;


        public ClienteService(IEntityBaseRepository<Cliente> entityRepository, 
                               IUnitOfWork unitOfWork, 
                               IAppContext appContext,
                               IReporteService reporteService,
                               ISevice service) : base(entityRepository, unitOfWork, appContext)
        {
            this.reporteService = reporteService;
            this.service = service;
        }

        public override ClienteDto Update(ClienteDto dto)
        {
            if (dto.TipoPersona == Const.TipoPersona.Fisica)
            {
                dto.RazonSocial = null;
            }
            if (dto.TipoPersona == Const.TipoPersona.Juridica)
            {
                dto.Nombre = null;
                dto.Apellido = null;
            }
            return base.Update(dto);
        }


        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Cliente entity, ClienteDto dto, bool isNew)
        {
            /* Validaciones si es una Persona Fisica */
            if (dto.TipoPersona == Const.TipoPersona.Fisica)
            {
                if (string.IsNullOrWhiteSpace(dto.Nombre)) throw new System.ArgumentException("El Nombre es obligatorio.");
                if (string.IsNullOrWhiteSpace(dto.Apellido)) throw new System.ArgumentException("El Apellido es obligatorio.");
            }

            /* Validaciones si es una Persona Juridica */
            else if (dto.TipoPersona == Const.TipoPersona.Juridica)
            {
                if (string.IsNullOrWhiteSpace(dto.RazonSocial)) throw new System.ArgumentException("La Razon Social es obligatoria.");
            }

            else throw new System.ArgumentException("El el Tipo de Persona indicada no es válida.");

            /* Validaciones generales */
            if (string.IsNullOrWhiteSpace(dto.Direccion)) throw new System.ArgumentException("La Dirección es obligatoria.");
            if (dto.DniCuit == 0) throw new System.ArgumentException("El DNI/CUIT es obligatorio.");
            if (dto.DniCuit < 0) throw new System.ArgumentException("El DNI/CUIT indicado no es válido.");
            if ((dto.TelefonoContacto ?? 0) < 0) throw new System.ArgumentException("El Telefono de Contacto indicado no es válido.");
        }


        public Stream ExportarExcel()
        {
            var exportarCliente = new List<int>();
            exportarCliente.Add(1);
            return this.reporteService.GenerarExcel(exportarCliente);
        }

        public Stream ClientesReporte()
        {
            var ClientesDto = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDto>>(this.entityRepository.AllIncludingAsNoTracking()).Select(x => new ClientePdfDto
            {
                ID = x.ID,
                Nombre = x.Nombre ?? " - ",
                RazonSocial = x.RazonSocial ?? " - ",
                Apellido = x.Apellido ?? " - ",
                Direccion = x.Direccion ?? " - ",
                DniCuit = x.DniCuit,
                Email = x.Email ?? " - ",
                TelefonoContacto = x.TelefonoContacto ?? 0
            })
                .ToList();
            if (ClientesDto.Count() != 0)
            {
                using (var report = new Reportes.PDF.CrystalReport1())
                {
                    return this.service.GetReportPDF(report, ClientesDto);
                }
            }
            return null;
        }

    }
}
