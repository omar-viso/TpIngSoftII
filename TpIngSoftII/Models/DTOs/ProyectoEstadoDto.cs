﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class ProyectoEstadoDto : IDto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}
