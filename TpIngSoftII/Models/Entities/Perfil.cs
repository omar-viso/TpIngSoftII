using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class Perfil : IEntityBase
    {
        public int ID { get; set; }
        public Tipo TipoPerfil { get; set; }
        public decimal ValorHorario { get; set; }

        public virtual ICollection<EmpleadoPerfil> Empleados { get; set; }

        public enum Tipo
        {
            analista,
            desrrollador,
            tester,
            implementador,
            capacitador,
            supervisor
        }
    }
}
