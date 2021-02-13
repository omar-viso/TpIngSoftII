using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class EmpleadoPerfilDto : IDto
    {
        public int ID { get; set; }

        public int EmpleadoID { get; set; }
        public string EmpleadoNombre { get; set; }

        public int PerfilID { get; set; }
        public string PerfilDescripcion { get; set; }
    }
}
