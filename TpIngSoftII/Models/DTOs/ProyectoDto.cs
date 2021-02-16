using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class ProyectoDto : IDto
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }
        public string Nombre { get; set; }
        public int ProyectoEstadoID { get; set; }
        public string ProyectoEstadoDescripcion { get; set; }
        //public ICollection<Tareadto> tareas { get; set; }

    }
}
