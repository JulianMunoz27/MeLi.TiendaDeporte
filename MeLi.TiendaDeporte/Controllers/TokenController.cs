using MeLi.TiendaDeporte.Application.Common;
using MeLi.TiendaDeporte.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MeLi.TiendaDeporte.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Obtiene el token necesario para poder consumir los endpoints, requiere una clave secreta (mirar el archivo Terms).
        /// </summary>
        /// <param name="secret"></param>
        /// <returns>Token de autorizacion.</returns>
        [HttpPost()]
        public IActionResult Login([FromBody] string secret)
        {
            if (secret == Terms.Secret)
            {
                var jwt = new JWT(_configuration);
                var token = jwt.GenerateJWTToken("user");
                return Ok(new { token });
            }

            return Unauthorized(new DefaultApiResponse() { Response = "user Unauthorized.", HasError = true });
        }
    }
}
