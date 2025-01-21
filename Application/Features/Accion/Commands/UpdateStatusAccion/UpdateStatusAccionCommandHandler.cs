using Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Commands.UpdateStatusAccion
{
    /// <summary>
    ///  Update Status Command Handler
    /// </summary>
    public class UpdateStatusAccionCommandHandler : IRequestHandler<UpdateStatusAccionCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStatusAccionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateStatusAccionCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var accionToUpdateStatus = await _unitOfWork.accionesRepository.GetById(request.Id.ToString());

                if (accionToUpdateStatus != null)
                {
                    var resultUpdateStatus = await _unitOfWork.accionesRepository.GetUpdateStatus(request.Id.ToString());

                    if (resultUpdateStatus.Result)
                    {
                        CodeResult = StatusCodes.Status200OK.ToString();

                        if (resultUpdateStatus.Estado)
                        {
                            Message = "Se completó la actividad";
                        }
                        else
                        {
                            Message = "Se inicializó la actividad";
                        }

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
