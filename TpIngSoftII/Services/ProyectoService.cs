﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class ProyectoService : EntityAppServiceBase<Proyecto, ProyectoDto>, IProyectoService
    {

        public ProyectoService(IEntityBaseRepository<Proyecto> entityRepository, IUnitOfWork unitOfWork) : base(entityRepository, unitOfWork)
        {
        }

        /* Hacer Override de los metodos que necesite customizar (validaciones, logicas, etc.) heredados de EntityAppServiceBase */
        
    }
}
