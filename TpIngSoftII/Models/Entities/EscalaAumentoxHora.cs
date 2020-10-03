using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class EscalaAumentoxHora : IEntityBase
    {
        public int ID { get; set; }
        public float LimiteHoras { get; set; }
        public float PorcentajeAumento { get; set; }
    }
}
