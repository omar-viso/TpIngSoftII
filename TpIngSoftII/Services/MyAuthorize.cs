using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Transactions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Services
{
    public class MyAuthorize : AuthorizeAttribute
    {
        //public string Permisos { get; set; }
        private readonly IEmpleadoService empleadoService;


        public MyAuthorize(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            this.SetAppContext(actionContext);

            return base.IsAuthorized(actionContext);
        }

        private void SetAppContext(HttpActionContext actionContext)
        {
            var scope = actionContext.Request.GetDependencyScope();

            var appContext = scope.GetService(typeof(IAppContext)) as IAppContext;

            var principal = HttpContext.Current?.User;

            if(principal != null)
            {
                var claims = ((ClaimsIdentity)principal.Identity).Claims;
                var nombreUsuario = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                var passwordUsuario = claims.FirstOrDefault(c => c.Type == "Password");

                

                appContext.SetEmpleado(this.empleadoService.GetEmpleadoUsuarioPassword(nombreUsuario.Value, passwordUsuario.Value));
            }
        }

    }
}
