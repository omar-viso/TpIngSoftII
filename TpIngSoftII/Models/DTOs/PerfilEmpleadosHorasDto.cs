using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class PerfilEmpleadosHorasDto
    {
        public string PerfilDescripcion { get; set; }
        public ICollection<EmpleadoHorasDto> EmpleadosHoras {get;set;}
    }
}
