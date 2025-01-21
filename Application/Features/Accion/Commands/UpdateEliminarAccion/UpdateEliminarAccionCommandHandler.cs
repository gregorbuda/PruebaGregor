using Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Commands.UpdateEliminarAccion
{
    /// <summary>
    ///  Update Delete Status Command Handler
    /// </summary>
    public class UpdateEliminarAccionCommandHandler : IRequestHandler<UpdateEliminarAccionCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEliminarAccionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateEliminarAccionCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var accionToUpdateEliminar = await _unitOfWork.accionesRepository.GetById(request.Id.ToString());

                if (accionToUpdateEliminar != null)
                {
                    if (!accionToUpdateEliminar.Eliminar)
                    {
                        var result = await _unitOfWork.accionesRepository.GetUpdateStatusEliminacion(request.Id.ToString());

                        if (result.Result)
                        {
                            CodeResult = StatusCodes.Status200OK.ToString();
                            Message = "Se eliminó correctamente la acción";
                            success = true;
                            Result = true;
                        }
                        else
                        {
                            CodeResult = StatusCodes.Status500InternalServerError.ToString();
                            Message = "Error interno del servidor";
                            success = false;
                            Result = false;
                        }
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status400BadRequest.ToString();
                        Message = "Ya la acción ha sido eliminada";
                        Result = false;
                        success = false;
                    }
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Acción no encontrada";
                    Result = false;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Error interno del servidor";
                success = false;
                Result = false;
            }
            ApiResponse<bool> response = new ApiResponse<bool>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = Result,
                Success = success
            };

            return response;
        }
    }
}
