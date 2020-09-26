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
    [RoutePrefix("api/Tareas")]
    public class TareaController : ApiController
    {
        private readonly ITareaService tareaService;

        public TareaController(ITareaService tareaService)
        {
            this.tareaService = tareaService;
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<TareaDto>))]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody] TareaDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = tareaService.Update(dto);
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
                var dtoUpdated = tareaService.GetAll();
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
                var dtoUpdated = tareaService.GetById(id);
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
                this.tareaService.DeleteById(id);
                response = request.CreateResponse(HttpStatusCode.OK, new { sucess = true });
            }

            return response;

        }

    }

}
