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
    public interface IClienteService : IEntityAppServiceBase<Cliente, ClienteDto>
    {
        Stream ExportarExcel();
        Stream ClientesReporte();
    }
}
