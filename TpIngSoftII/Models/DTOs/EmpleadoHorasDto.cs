using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class EmpleadoHorasDto
    {
        public EmpleadoDto Empleado { get; set; }
        public decimal CantidadHoras { get; set; }
    }
}
