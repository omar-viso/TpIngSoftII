using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class EmpleadoNombreHorasDto
    {
        public string EmpleadoNombre { get; set; }
        public string EmpleadoApellido { get; set; }
        public decimal CantidadHorasAdeudadas { get; set; }
    }
}
