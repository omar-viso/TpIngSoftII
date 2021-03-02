using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Transactions;
using System.Web;
using System.Web.Http;
using TpIngSoftII.Interfaces;
using TpIngSoftII.Interfaces.Repositories;
using TpIngSoftII.Interfaces.Services;
using TpIngSoftII.Models.DTOs;
using TpIngSoftII.Models.Entities;
using static TpIngSoftII.Models.Entities.Proyecto;

namespace TpIngSoftII.Models
{
    public class ApiControllerBase : ApiController
    {

        public ApiControllerBase(){}

        protected int CurrentUserID
        {
            get
            {
                var scope = Request.GetDependencyScope();
                var appContext = scope.GetService(typeof(IAppContext)) as IAppContext;
                return appContext.EmpleadoID;
            }
        }

        protected HttpResponseMessage ResponseExcel(HttpRequestMessage request, Stream xlsx, string fileName)
        {
            HttpResponseMessage response = null;

            response = request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(xlsx);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName + ".xlsx"
            };
            return response;

        }

        protected HttpResponseMessage ResponsePDF(HttpRequestMessage request, Stream pdf, string fileName)
        {
            HttpResponseMessage response = null;

            response = request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StreamContent(pdf);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName + ".pdf"
            };
            return response;
        }


    }
}
