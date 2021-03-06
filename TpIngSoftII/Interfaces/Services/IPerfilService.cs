﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;

namespace TpIngSoftII.Interfaces.Services
{
    public interface IPerfilService : IEntityAppServiceBase<Perfil,PerfilDto>
    {
        Stream PerfilesReporte();
    }
}
