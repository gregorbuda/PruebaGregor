using Application.Features.Accion.Commands.CreateAccion;
using Application.Features.Accion.Commands.UpdateAccion;
using Application.Features.Accion.Commands.UpdateEliminarAccion;
using Application.Features.Accion.Commands.UpdateStatusAccion;
using Application.Features.Accion.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [SwaggerTag("The Accion Type REST services")]
    public class AccionController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public AccionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creación de acción
        /// </summary>
        /// <param name="command">The data Accion.</param>
        /// <returns>
        /// A Accion Id 
        /// </returns>
        /// <remarks>
        /// Creación de acción
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost("CreacionAccion")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<string>>> CreateAccion([FromBody] CreateAccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update status
        /// </summary>
        /// <param name="command">The data Accion.</param>
        /// <returns>
        /// Bool 
        /// </returns>
        /// <remarks>
        /// Update status
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("ActualizarAccion")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateAccion([FromBody] UpdateAccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update status Eliminar
        /// </summary>
        /// <param name="command">The data Accion.</param>
        /// <returns>
        /// Bool 
        /// </returns>
        /// <remarks>
        /// Update status Eliminar
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("EliminarAccion")]
        [Authorize(Policy = "AdminOnly")]

        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateStatusEliminar([FromBody] UpdateEliminarAccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update status Acción
        /// </summary>
        /// <param name="command">The data Accion.</param>
        /// <returns>
        /// Bool 
        /// </returns>
        /// <remarks>
        /// Update status Acción
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("CambiarEstado")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateStatusAccion([FromBody] UpdateStatusAccionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Listar todas las acciones
        /// </summary>
        /// <param name="">.</param>
        /// <returns>
        /// Listar todas las acciones
        /// </returns>
        /// <remarks>
        /// Listar todas las acciones
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ListarAcciones")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<AccionTexto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<List<AccionTexto>>>> GetAllAccion()
        {
            var query = new GetAllAccion();
            var list = await _mediator.Send(query);
            return Ok(list);
        }

        /// <summary>
        /// Listar todas las acciones por estado
        /// </summary>
        /// <param name="">.</param>
        /// <returns>
        /// Listar todas las acciones por estado
        /// </returns>
        /// <remarks>
        /// Listar todas las acciones por estado
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ListarAccionesPorEstado/{Estado}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<AccionTexto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<List<AccionTexto>>>> GetAccionByEstado(bool Estado)
        {
            var query = new GetByStatus(Estado);
            var list = await _mediator.Send(query);
            return Ok(list);
        }

        /// <summary>
        /// Listar todas las acciones por accion
        /// </summary>
        /// <param name="">.</param>
        /// <returns>
        /// Listar todas las acciones por accion
        /// </returns>
        /// <remarks>
        /// Listar todas las acciones por accion
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ListarAccionesPorAccion/{Accion}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<AccionTexto>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<List<AccionTexto>>>> GetAccionByAccion(string Accion)
        {
            var query = new GetByDescripcionAccion(Accion);
            var list = await _mediator.Send(query);
            return Ok(list);
        }
    }
}
