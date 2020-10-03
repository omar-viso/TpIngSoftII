using System;
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
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public virtual ICollection<EmpleadoPerfil> Perfiles { get; set; }    
    }
}
