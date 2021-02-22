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
    [RoutePrefix("api/HorasTrabajadas")]
    public class HorasTrabajadasController : ApiController
    {
        private readonly IHorasTrabajadasService horasTrabajadasService;

        public HorasTrabajadasController(IHorasTrabajadasService horasTrabajadasService)
        {
            this.horasTrabajadasService = horasTrabajadasService;
        }

        [HttpPost]
        [ResponseType(typeof(HorasTrabajadasDto))]
        [Route("update")]
        [MyAuthorize()]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody] HorasTrabajadasDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = horasTrabajadasService.Update(dto);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<HorasTrabajadasDto>))]
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
                var dtoUpdated = horasTrabajadasService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(HorasTrabajadasDto))]
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
                var dtoUpdated = horasTrabajadasService.GetById(id);
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
                this.horasTrabajadasService.DeleteById(id);
                response = request.CreateResponse(HttpStatusCode.OK, new { sucess = true });
            }

            return response;

        }

        [HttpPost]
        [Route("getHsOB")]
        [ResponseType(typeof(decimal))]
        [MyAuthorize()]
        public HttpResponseMessage getHsOB(HttpRequestMessage request, HorasTrabajadasDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = horasTrabajadasService.CantidadHsOB(dto);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [Route("informeSemanalHsOB")]
        [ResponseType(typeof(InformeSemanalHsOBDto))]
        [MyAuthorize()]
        public HttpResponseMessage informeSemanalHsOB(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = horasTrabajadasService.InformeSemanalHsOB();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<HorasTrabajadasEstadoDto>))]
        [Route("GetHorasTrabajadasEstado")]
        [MyAuthorize()]
        public HttpResponseMessage GetHorasTrabajadasEstado(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = horasTrabajadasService.GetHorasTrabajadasEstado();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }
    }

}
