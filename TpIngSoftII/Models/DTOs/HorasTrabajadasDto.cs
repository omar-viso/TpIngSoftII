using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class HorasTrabajadasDto : IDto
    {
        public int ID { get; set; }
        public int ProyectoID { get; set; }
        public int TareaID { get; set; }
        public decimal CantHoras { get; set; }
        public DateTime Fecha { get; set; }
        public int EstadoHoras { get; set; }
    }
}
