using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class ClienteReporteDto
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DniCuit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string TelefonoContacto { get; set; }
        public string Email { get; set; }
    }
}
