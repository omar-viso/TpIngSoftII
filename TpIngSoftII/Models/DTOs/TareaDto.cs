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

        public int ProyectoID { get; set; }
        public string ProyectoNombre { get; set; }

        public int EmpleadoPerfilID { get; set; }
        public string EmpleadoPerfilNombreEmplado { get; set; }
        public string EmpleadoPerfilDescripcionPerfil { get; set; }

        public string Nombre { get; set; }
        public decimal HorasEstimadas { get; set; }
        public decimal HorasOB { get; set; }
    }
}
