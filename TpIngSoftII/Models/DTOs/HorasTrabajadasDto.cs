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
        public int IDProyecto { get; set; }
        public int IDTarea { get; set; }
        public float CantHoras { get; set; }
        public DateTime Fecha { get; set; }
        public int EstadoHoras { get; set; }
    }
}
