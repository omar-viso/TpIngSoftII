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
    [RoutePrefix("api/Empleados")]
    public class EmpleadoController : ApiController
    {
        private readonly IEmpleadoService empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        [HttpPost]
        [ResponseType(typeof(EmpleadoDto))]
        [Route("update")]
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

    }

}
