using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class HorasPerfilesProyectoDto
    {
        public string NombreProyecto { get; set; }
        public IEnumerable <PerfilHorasDto>  PerfilHoras { get; set; }
    }
}
