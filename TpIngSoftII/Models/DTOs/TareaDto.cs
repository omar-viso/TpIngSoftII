using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class TareaDto : IDto
    {
        public int ID { get; set; }
        public int IDProyecto { get; set; }
        public int IDEmpleado { get; set; }
        public int IDPerfil { get; set; }
        public string Nombre { get; set; }
        public decimal HorasEstimadas { get; set; }
        public decimal HorasOB { get; set; }
    }
}
