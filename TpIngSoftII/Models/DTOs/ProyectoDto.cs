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
        public int IdCliente { get; set; }
        public virtual ClienteDto Cliente { get; set; }
        public string Nombre { get; set; }
        public string EstadoProyecto { get; set; }
        //public ICollection<Tareadto> tareas { get; set; }
    }
}