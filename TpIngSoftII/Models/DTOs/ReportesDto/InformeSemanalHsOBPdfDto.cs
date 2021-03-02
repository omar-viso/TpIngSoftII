using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class InformeSemanalHsOBPdfDto
    {
        public string ProyectoNombre { get; set; }
        public string TareaNombre { get; set; }
        public decimal SubtotalHsOB { get; set; }
    }
}
