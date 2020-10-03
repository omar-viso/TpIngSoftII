using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class Tarea : IEntityBase
    {
        public int ID { get; set; }

        public int ProyectoID { get; set; }
        public virtual Proyecto Proyecto { get; set; }

        public int EmpleadoPerfilID { get; set; }
        public virtual EmpleadoPerfil EmpleadoPerfil { get; set; }

        public string Nombre { get; set; }
        public decimal HorasEstimadas { get; set; }
        public decimal HorasOB { get; set; }
        public virtual ICollection<HorasTrabajadas> HorasTrabajadas { get; set; }
    }
}
