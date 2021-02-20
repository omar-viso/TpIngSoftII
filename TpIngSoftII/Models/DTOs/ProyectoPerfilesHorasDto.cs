using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class ProyectoPerfilesHorasDto
    {
        public string ProyectoNombre { get; set; }
        public IEnumerable<PerfilHorasDto> PerfilesHoras { get; set; }
    }
}
