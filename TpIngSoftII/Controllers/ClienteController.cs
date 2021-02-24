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
    [RoutePrefix("api/Clientes")]
    public class ClienteController : ApiControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpPost]
        [ResponseType(typeof(ClienteDto))]
        [Route("update")]
        [MyAuthorize()]
        public HttpResponseMessage Update(HttpRequestMessage request, [FromBody] ClienteDto dto)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                var dtoUpdated = clienteService.Update(dto);
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<ClienteDto>))]
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
                var dtoUpdated = clienteService.GetAll();
                response = request.CreateResponse(HttpStatusCode.OK, dtoUpdated);
            }

            return response;

        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(ClienteDto))]
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
                var dtoUpdated = clienteService.GetById(id);
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
                this.clienteService.DeleteById(id);
                response = request.CreateResponse(HttpStatusCode.OK, new { sucess = true });
            }

            return response;

        }

        [HttpGet]
        [Route("ExportarClientes")]
        [MyAuthorize]
        public HttpResponseMessage ExportarClientes(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, new { sucess = false });
            }
            else
            {
                Stream excel = this.clienteService.ExportarExcel();
                response = ResponseExcel(request, excel, "Listado de Clientes");
            }

            return response;
        }
    }

}
