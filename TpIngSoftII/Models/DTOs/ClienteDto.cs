using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class ClienteDto : IDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public int? TelefonoFijo { get; set; }
        public int? TelefonoCelular { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<ProyectoDto> Proyectos { get; set; }
    }
}
