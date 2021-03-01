using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class HsAdeudadasProyectoEmpleadoPdfDto
    {
        public string ProyectoNombre { get; set; }
        public string EmpleadoNombreApellido { get; set; }
        public decimal CantidadHorasAdeudadas { get; set; }
    }
}
