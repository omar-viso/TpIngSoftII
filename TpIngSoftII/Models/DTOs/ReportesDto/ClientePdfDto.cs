﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Models.DTOs
{
    public class ClientePdfDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
    }
}
