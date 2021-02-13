﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class EmpleadoDto : IDto
    {
        public int ID { get; set; } 
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<EmpleadoPerfilDto> Perfiles { get; set; }

    }
}
