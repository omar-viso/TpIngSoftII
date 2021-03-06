﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class Empleado : IEntityBase
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Dni { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int RolID { get; set; }
        public virtual Rol Rol { get; set; }

        public virtual ICollection<EmpleadoPerfil> Perfiles { get; set; }    
    }
}
