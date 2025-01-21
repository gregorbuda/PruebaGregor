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

namespace Application.Features.Accion.Commands.CreateAccion
{
    public class CreateAccionCommandsHandler : IRequestHandler<CreateAccionCommand, ApiResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAccionCommandsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<string>> Handle(CreateAccionCommand request, CancellationToken cancellationToken)
        {
            var accionEntity = _mapper.Map<Acciones>(request);
            accionEntity.Id = Guid.NewGuid().ToString();
            Acciones accion = null;
            string accionId = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                accion = await _unitOfWork.accionesRepository.AddAsync(accionEntity);

                if (accion.Id != null)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Se registró correctamente la acción";
                    accionId = accion.Id;
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo registrar la acción";
                    accionId = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Error interno del servidor";
                accionId = null;
                success = false;
            }

            ApiResponse<string> response = new ApiResponse<string>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = accionId,
                Success = success
            };

            return response;
        }
    }
}
