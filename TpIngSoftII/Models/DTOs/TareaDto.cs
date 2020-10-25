﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models.DTOs
{
    public class TareaDto : IDto
    {
        public int ID { get; set; }
        public int ProyectoID { get; set; }
        public int EmpleadoID { get; set; }
        public int PerfilID { get; set; }
        public string Nombre { get; set; }
        public decimal HorasEstimadas { get; set; }
        public decimal HorasOB { get; set; }
    }
}
