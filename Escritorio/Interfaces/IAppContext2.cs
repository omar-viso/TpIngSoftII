﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace TpIngSoftII.Interfaces
{
    public interface IAppContext2
    {
        Container Contenedor { get; set; }

        void SetContenedor(Container contenedor);

    }
}
