using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Transactions;
using System.Web;
using System.Web.Http;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Models
{
    public class ApiControllerBase : ApiController
    {

        public ApiControllerBase(){}

        protected int CurrentUserID
        {
            get
            {
                var scope = Request.GetDependencyScope();
                var appContext = scope.GetService(typeof(IAppContext)) as IAppContext;
                return appContext.EmpleadoID;
            }
        }

    }
}
