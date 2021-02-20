using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class LiquidacionDto
    {
        public int CantidadProyectosLiquidados { get; set; }
        public int CantidadTareasLiquidados { get; set; }

        public int CantidadPerfiles { get; set; }
        public int AntiguedadEmpleado { get; set; }

        public decimal CantidadHsNoOBLiquidados { get; set; }
        public decimal CantidadHsOBLiquidados { get; set; }
        public decimal CantidadHsTotalesLiquidados { get; set; }

        public decimal? PorcentajeAplicadoAntiguedad { get; set; }
        public decimal? PorcentajeAplicadoCantidadPerfiles { get; set; }
        public decimal? PorcentajeAplicadoCantidadHoras { get; set; }

        public decimal TotalLiquidado { get; set; }

        public IEnumerable<PerfilDto> ValoresInformativosPerfilHora { get; set; } // Para mostrar los perfiles con sus valores x hora
        public decimal ValorPorcentajeDeHoraOB { get; set; }  // Para mostrar el porcentaje que se paga la Hs OB con respecto al valor de una hora de "X" Perfil normal

    }
}
