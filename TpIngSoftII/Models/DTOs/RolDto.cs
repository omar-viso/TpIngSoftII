using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class RolDto : IDto
    {
        public int ID { get; set; }
        public string RolDescripcion { get; set; }
    }
}
