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
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using TpIngSoftII.Reportes;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class PerfilService : EntityAppServiceBase<Perfil, PerfilDto>, IPerfilService
    {
        private readonly ISevice service;

        public PerfilService(IEntityBaseRepository<Perfil> entityRepository, IUnitOfWork unitOfWork, IAppContext appContext, ISevice service) : base(entityRepository, unitOfWork, appContext)
        {
            this.service = service;
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        protected override void ValidarEntityUpdating(Perfil entity, PerfilDto dto, bool isNew)
        {
            if (dto.ValorHorario <= 0) throw new System.ArgumentException("El valor de las horas es obligatorio y tiene que ser mayor a 0.");
            if (string.IsNullOrWhiteSpace(dto.Descripcion)) throw new System.ArgumentException("La descripcion del perfil es obligatoria");           
        }

        public Stream PerfilesReporte()
        {
            var perfilesDto = Mapper.Map<IEnumerable<Perfil>, IEnumerable<PerfilDto>>(this.entityRepository.AllIncludingAsNoTracking()).Select(x => new PerfilPdfDto
            {
                ID = x.ID,
                Descripcion = x.Descripcion ?? " - ",
                ValorHorario = x.ValorHorario
            })?.OrderBy(x => x.Descripcion)
                .ToList();

            using (var report = new Reportes.PDF.CrystalReportPerfiles())
            {
                if (perfilesDto.Count() == 0)
                {
                    var vacio = new PerfilPdfDto
                    {
                        ID = 0,
                        Descripcion = "NO EXISTEN PERFILES",
                        ValorHorario = 0
                    };

                    perfilesDto.Add(vacio);
                }
                return this.service.GetReportPDF(report, perfilesDto);
            }
        }
    }
}
