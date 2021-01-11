using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class HorasTrabajadas : IEntityBase
    {
        public int ID { get; set; }
        public int ProyectoID { get; set; }
        public int TareaID { get; set; }
        public virtual Tarea Tarea { get; set; }
        public decimal CantHoras { get; set; }
        public DateTime Fecha { get; set; }
        public int HorasTrabajadasEstadoID { get; set; }
        public bool EsOB { get; set; }
        public virtual HorasTrabajadasEstado HorasTrabajadasEstado { get; set; }

        /*
        public enum Estado
        {
            pagadas,
            adeudadas
        }
        */
    }
}
