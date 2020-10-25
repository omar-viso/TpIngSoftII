using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.Entities
{
    public class HorasTrabajadasEstado : IEntityBase
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<HorasTrabajadas> HorasTrabajadas { get; set; }
    }
}
