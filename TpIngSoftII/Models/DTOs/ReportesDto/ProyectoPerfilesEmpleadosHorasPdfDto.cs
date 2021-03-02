using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class ProyectoPerfilesEmpleadosHorasPdfDto
    {
        public string ProyectoNombre { get; set; }
        public string PerfilDescripcion { get; set; }
        public string NombreApellido { get; set; }
        public decimal CantidadHoras { get; set; }
    }
}
