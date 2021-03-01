using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class PerfilPdfDto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorHorario { get; set; }
    }
}
