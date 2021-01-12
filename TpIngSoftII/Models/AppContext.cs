using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models
{
    public class AppContext : IAppContext
    {
        public int EmpleadoID { get; set; }
        
        public void SetEmpleado(int empleadoId)
        {
            EmpleadoID = empleadoId;
        }

    }
}
