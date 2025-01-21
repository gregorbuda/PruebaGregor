using Application.Contracts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Models;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Commands.UpdateAccion
{
    /// <summary>
    ///  Update  Accion Command Handler
    /// </summary>
    public class UpdateAccionCommandHandler : IRequestHandler<UpdateAccionCommand, ApiResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAccionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateAccionCommand request, CancellationToken cancellationToken)
        {
            var accionEntity = _mapper.Map<Acciones>(request);
            Acciones accion = new Acciones();
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                var accionToUpdate = await _unitOfWork.accionesRepository.GetById(request.Id.ToString());

                if (accionToUpdate != null)
                {
                    _unitOfWork.accionesRepository.UpdateEntity(accionToUpdate);

                    await _unitOfWork.Complete();

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Se actualizó correctamente la acción";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Acción no encontrada";
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Error interno del servidor";
                success = false;
            }

            ApiResponse<bool> response = new ApiResponse<bool>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = success,
                Success = success
            };

            return response;
        }
    }
}
