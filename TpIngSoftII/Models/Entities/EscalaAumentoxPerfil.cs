using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class EscalaAumentoxPerfil : IEntityBase
    {
        public int ID { get; set; }
        public int LimitecantPerfiles { get; set; }
        public decimal PorcentajeAumento { get; set; }
    }
}
