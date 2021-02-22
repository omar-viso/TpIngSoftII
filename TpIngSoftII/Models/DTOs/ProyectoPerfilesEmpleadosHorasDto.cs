using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class ProyectoPerfilesEmpleadosHorasDto
    {
        public string ProyectoNombre { get; set; }
        public ICollection<PerfilEmpleadosHorasDto> PerfilesEmpleadosHoras {get;set;}
    }
}
