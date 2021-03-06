﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class EmpleadoPdfDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string RolDescripcion { get; set; }
        public long Dni { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
    }
}
