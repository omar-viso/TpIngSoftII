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
        public string Descripcion { get; set; }

        public decimal ValorHorario { get; set; }

        public virtual ICollection<EmpleadoPerfil> Empleados { get; set; }

        /* -- Los valores indicados en los enums, se insertaran con ID FIJOS al correr las
         * Configuraciones de base, y en Constanstes.cs se definiran para poder utilizar el nombre y no por ID --
        public enum Tipo
        {
            analista,
            desrrollador,
            tester,
            implementador,
            capacitador,
            supervisor
        }
        */
    }
}
