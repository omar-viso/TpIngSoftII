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

    }

}
