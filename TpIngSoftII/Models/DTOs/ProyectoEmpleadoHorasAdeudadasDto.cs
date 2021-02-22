using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class ProyectoEmpleadoHorasAdeudadasDto
    {
        public string ProyectoNombre { get; set; }
        public ICollection<EmpleadoNombreHorasDto> EmpleadoHoras { get; set; }
    }
}
