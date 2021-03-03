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
        private readonly Container contenedor;


        public AppContext2(Container contenedor)
        {
            this.contenedor = contenedor;
        }
    }
}
