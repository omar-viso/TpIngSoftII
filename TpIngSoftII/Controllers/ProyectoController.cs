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
        /*
        [HttpPost]
        //[ProducesResponseType(typeof(IEnumerable<ProyectoDto>))]
        [Route("UpdateProyecto")]
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
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;

        }
        */
        [HttpGet]
        [ResponseType(typeof(IEnumerable<ProyectoDto>))]
        [Route("GetProyectos")]
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
        [Route("details/{id:int}")]
        [ResponseType(typeof(ProyectoDto))]
        public HttpResponseMessage GetProyecto(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
               // var dtoUpdated = proyectoService.GetById(id);
                response = request.CreateResponse(HttpStatusCode.OK);
            }

            return response;

        }

        // CREAR EL RESTO DE LOS METODOS, DTO Y SERVICES
    }

}
