﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models
{
    public class AppContext : IAppContext
    {
        public int EmpleadoID { get; set; }
        public int EmpleadoRolID { get; set; }

        public void SetEmpleado(int empleadoId)
        {
            EmpleadoID = empleadoId;
        }

        public void SetEmpleadoRol(int rolId)
        {
            EmpleadoRolID = rolId;
        }

    }
}
