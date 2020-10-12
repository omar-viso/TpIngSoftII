﻿using System;
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
        public decimal CantHoras { get; set; }
        public DateTime Fecha { get; set; }
        public Estado EstadoHoras { get; set; }
        public enum Estado
        {
            pagadas,
            adeudadas
        }
        
    }
}
