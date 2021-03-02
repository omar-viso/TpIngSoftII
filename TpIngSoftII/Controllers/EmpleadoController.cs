using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Services;

namespace TpIngSoftII.Controllers
{
    [RoutePrefix("api/Empleados")]
    public class EmpleadoController : ApiControllerBase
    {
        private readonly IEmpleadoService empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        [HttpPost]
        [ResponseType(typeof(EmpleadoDto))]
        [Route("update")]
        [MyAuthorize()]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody] EmpleadoDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.Update(dto);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<EmpleadoDto>))]
        [Route()]
        [MyAuthorize()]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(EmpleadoDto))]
        [MyAuthorize()]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpDelete]
        [Route("{id:int}")]
        [MyAuthorize()]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, new { sucess = false });
            }
            else
            {
                this.empleadoService.DeleteById(id);
                response = request.CreateResponse(HttpStatusCode.OK, new { sucess = true });
            }

            return response;

        }

        [HttpGet]
        [Route("DameMisDatos")]
        [ResponseType(typeof(EmpleadoDto))]
        [MyAuthorize()]
        public HttpResponseMessage DameMisDatos(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.DameMisDatos();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [Route("GetPerfilesDeEmpleado")]
        [ResponseType(typeof(IEnumerable<PerfilDto>))]
        [MyAuthorize()]
        public HttpResponseMessage GetPerfilesDeEmpleado(HttpRequestMessage request, int empleadoID)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.GetPerfilesDeEmpleado(empleadoID);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [Route("GetEmpleadosDePerfil")]
        [ResponseType(typeof(IEnumerable<EmpleadoDto>))]
        [MyAuthorize()]
        public HttpResponseMessage GetEmpleadosDePerfil(HttpRequestMessage request, int perfilID)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.GetEmpleadosDePerfil(perfilID);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [Route("GetEmpleadoPerfilID")]
        [ResponseType(typeof(IEnumerable<EmpleadoDto>))]
        [MyAuthorize()]
        public HttpResponseMessage GetEmpleadoPerfilID(HttpRequestMessage request, int empleadoID, int perfilID)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.GetEmpleadoPerfilID(empleadoID, perfilID);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [Route("GetEmpleadoPerfil")]
        [ResponseType(typeof(EmpleadoPerfilDto))]
        [MyAuthorize()]
        public HttpResponseMessage GetEmpleadoPerfil(HttpRequestMessage request, int empleadoPerfilID)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = empleadoService.GetEmpleadoPerfil(empleadoPerfilID);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [Route("EmpleadosReporte")]
        [MyAuthorize()]
        public HttpResponseMessage EmpleadosReporte(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                Stream pdf = empleadoService.EmpleadosReporte();
                response = ResponsePDF(request, pdf, "Reporte de Empleados");
            }

            return response;

        }
    }

}
