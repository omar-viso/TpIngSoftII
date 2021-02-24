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
using TpIngSoftII.Models.Reportes;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IEntityBaseRepository<Cliente> clientesRepository;

        public ReporteService(IEntityBaseRepository<Cliente> clientesRepository)
        {
            this.clientesRepository = clientesRepository;        
        }

        private byte[] GeneracionExcel(List<int> input)
        {
            try
            {
                ExcelExport excel = new ExcelExport();
                byte[] arrBytes = { };

                if (input.Exists(x => x.Equals(1)))
                {
                    List<ClienteReporteDto> list = clientesRepository.GetAll().Select(x => new ClienteReporteDto
                    {
                        ID = x.ID.ToString(),
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        DniCuit = x.DniCuit.ToString(),
                        RazonSocial = x.RazonSocial,
                        Direccion = x.Direccion,
                        TelefonoContacto = x.TelefonoContacto.ToString(),
                        Email = x.Email
                    }).ToList();
                    arrBytes = excel.Export(list);
                }



                return arrBytes;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el excel", ex);
            }
        }

        public Stream GenerarExcel(List<int> generarOCs)
        {
            Stream xls = new MemoryStream(GeneracionExcel(generarOCs));

            return xls;
        }

    }
}
