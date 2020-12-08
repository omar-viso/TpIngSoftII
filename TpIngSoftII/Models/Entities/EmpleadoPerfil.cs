using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class EmpleadoPerfil : IEntityBase
    {
        public int ID { get; set; }

        public int EmpleadoID { get; set; }
        public virtual Empleado Empleado { get; set; }

        public int PerfilID { get; set; }
        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
