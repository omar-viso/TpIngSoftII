using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using TpIngSoftII.Interfaces;

namespace TpIngSoftII.Models
{
    public class AppContext2 : IAppContext2
    {
        public Container Contenedor { get; set; }


        public void SetContenedor(Container contenedor)
        {
            Contenedor = contenedor;
        }
    }
}
