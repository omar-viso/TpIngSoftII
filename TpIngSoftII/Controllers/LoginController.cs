using System.Net;
using System.Web.Http;
using System.Threading;
using TpIngSoftII.Models.Entities;
using TpIngSoftII.Services;
using TpIngSoftII.Interfaces.Services;
using System.Net.Http;

namespace TpIngSoftII.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private readonly IEmpleadoService empleadoService;

        public LoginController(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public HttpResponseMessage Authenticate(HttpRequestMessage request, [FromBody] LoginRequest login)
        {

            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                //TODO: Validate credentials Correctly, this code is only for demo !!
                //if (login == null) return response = request.CreateResponse(HttpStatusCode.BadRequest, new System.ArgumentException("Los datos de Usuario/Contraseña son obligatorios."));
                if (login == null) throw new System.ArgumentException("Los datos de Usuario/Contraseña son obligatorios.");

                int isCredentialValid = this.empleadoService.ValidarCredenciales(login);
                if (isCredentialValid != 0)
                {
                    var token = TokenGenerator.GenerateTokenJwt(login.Username, login.Password, isCredentialValid);
                    response = request.CreateResponse(HttpStatusCode.OK, token);

                    return response;
                }
                else
                {
                    throw new System.ArgumentException("Login fallido. Verifique usuario y contraseña, por favor.");

                    //return response = request.CreateResponse(HttpStatusCode.Unauthorized, new System.ArgumentException("Login fallido. Verifique usuario y contraseña, por favor."));
                }
            }

            return response;
        }
    }

}
