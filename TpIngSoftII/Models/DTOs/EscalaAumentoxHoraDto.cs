using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class EscalaAumentoxHoraDto : IDto
    {
        public int ID { get; set; }
        public decimal LimiteHoras { get; set; }
        public decimal PorcentajeAumento { get; set; }
    }
}
