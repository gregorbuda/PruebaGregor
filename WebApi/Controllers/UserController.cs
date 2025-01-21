using Application.Features.Seguridad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.Utils;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using WebApi.Utils;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetailsNotFound), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetailsNotAcceptable), (int)HttpStatusCode.NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetailsInternalServerError), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetailsUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [SwaggerTag("The User Type REST services")]
    public class UserController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="command">The data Accion.</param>
        /// <returns>
        /// Token
        /// </returns>
        /// <remarks>
        /// Login
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost("Login")]
        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<string>>> Login([FromBody] LoginCommands command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
