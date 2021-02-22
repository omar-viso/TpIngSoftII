using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Services;

namespace TpIngSoftII.Controllers
{
    [RoutePrefix("api/Proyectos")]
    public class ProyectoController : ApiController
    {
        private readonly IProyectoService proyectoService;

        public ProyectoController(IProyectoService proyectoService)
        {
            this.proyectoService = proyectoService;
        }
        
        [HttpPost]
        [ResponseType(typeof(ProyectoDto))]
        [Route("update")]
        [MyAuthorize()]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody] ProyectoDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.Update(dto);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }
        
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProyectoDto>))]
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
                var dtoUpdated = proyectoService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(ProyectoDto))]
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
                var dtoUpdated = proyectoService.GetById(id);
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
                this.proyectoService.DeleteById(id);
                response = request.CreateResponse(HttpStatusCode.OK , new { sucess = true });
            }

            return response;

        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProyectoEstadoDto>))]
        [Route("ProyectoEstados")]
        [MyAuthorize()]
        public HttpResponseMessage ProyectoEstados(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.ProyectoEstados();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpPost]
        [ResponseType(typeof(LiquidacionDto))]
        [Route("Liquidacion")]
        [MyAuthorize()]
        public HttpResponseMessage Liquidacion(HttpRequestMessage request, [FromBody] SolicitaLiquidacionDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.Liquidacion(dto);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProyectoPerfilesHorasDto>))]
        [Route("HorasTrabajadasPorProyectoPorPerfilTotales")]
        [MyAuthorize()]
        public HttpResponseMessage HorasTrabajadasPorProyectoPorPerfilTotales(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.HorasTrabajadasPorProyectoPorPerfilTotales();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProyectoPerfilesEmpleadosHorasDto>))]
        [Route("HorasTrabajadasPorProyectoPorPerfilPorEmpleadoTotales")]
        [MyAuthorize()]
        public HttpResponseMessage HorasTrabajadasPorProyectoPorPerfilPorEmpleadoTotales(HttpRequestMessage request, [FromUri] DateTime desde, [FromUri] DateTime hasta)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.HorasTrabajadasPorProyectoPorPerfilPorEmpleadoTotales(desde, hasta);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProyectoEmpleadoHorasAdeudadasDto>))]
        [Route("HorasAdeudadasPorProyectoPorEmpleadoTotales")]
        [MyAuthorize()]
        public HttpResponseMessage HorasAdeudadasPorProyectoPorEmpleadoTotales(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = proyectoService.HorasAdeudadasPorProyectoPorEmpleadoTotales();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }
    }

}
