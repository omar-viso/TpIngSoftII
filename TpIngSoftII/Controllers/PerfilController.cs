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
    [RoutePrefix("api/Perfiles")]
    public class PerfilController : ApiController
    {
        private readonly IPerfilService perfilService;

        public PerfilController(IPerfilService perfilService)
        {
            this.perfilService = perfilService;
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<PerfilDto>))]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody] PerfilDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = perfilService.Update(dto);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<PerfilDto>))]
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
                var dtoUpdated = perfilService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(PerfilDto))]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = perfilService.GetById(id);
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
                this.perfilService.DeleteById(id);
                response = request.CreateResponse(HttpStatusCode.OK, new { sucess = true });
            }

            return response;

        }

    }

}
