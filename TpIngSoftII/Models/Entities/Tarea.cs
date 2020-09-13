﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class Tarea : IEntityBase
    {
        public int ID { get; set; }
        public int IDProyecto { get; set; }
        public int IDEmpleado { get; set; }
        public int IDPerfil { get; set; }
        public string Nombre { get; set; }
        public float HorasEstimadas { get; set; }
        public float HorasOB { get; set; }
        public virtual ICollection<HorasTrabajadas> HorasTrabajadas { get; set; }
    }
}
