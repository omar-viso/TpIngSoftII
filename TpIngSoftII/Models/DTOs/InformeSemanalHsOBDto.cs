using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class InformeSemanalHsOBDto
    {
        public IEnumerable<SubtotalHsOBDto> TareasSubtotalesHsOB { get; set; }
        public decimal HsOBTotales { get; set; }
    }
}
