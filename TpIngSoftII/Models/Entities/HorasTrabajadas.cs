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
        public int IDProyecto { get; set; }
        public int IDTarea { get; set; }
        public float CantHoras { get; set; }
        public DateTime Fecha { get; set; }
        public Estado EstadoHoras { get; set; }
        public enum Estado
        {
            pagadas,
            adeudadas
        }
        
    }
}
