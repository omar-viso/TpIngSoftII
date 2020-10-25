﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class PerfilDto : IDto
    {
        public int ID { get; set; }
        public int PerfilTipoID { get; set; }
        public string PerfilTipoDescripcion { get; set; }
        public decimal ValorHorario { get; set; }
    }
}
