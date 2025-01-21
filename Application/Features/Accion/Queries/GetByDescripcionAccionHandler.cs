using Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Queries
{
    public class GetByDescripcionAccionHandler : IRequestHandler<GetByDescripcionAccion, ApiResponse<List<AccionTexto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByDescripcionAccionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<AccionTexto>>> Handle(GetByDescripcionAccion request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            List<AccionTexto> accionList = new List<AccionTexto>();
            String CodeResult = "";

            try
            {
                var list = await _unitOfWork.accionesRepository.GetByAccion(request._description);

                if (list.Count > 0)
                {
                    accionList = list.Select(a => new AccionTexto
                    {
                        Id = a.Id,
                        DescripcionAccion = a.DescripcionAccion,
                        Estado = a.Estado ? "Completado" : "No completado",
                        Eliminar = a.Eliminar ? "Eliminado" : "Sin eliminar"
                    }).ToList();



                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Lista de acciones.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "No se encontró data";
                    accionList = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Error interno del servidor";
                accionList = null;
                success = false;
            }

            ApiResponse<List<AccionTexto>> response = new ApiResponse<List<AccionTexto>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = accionList,
                Success = success
            };

            return response;
        }
    }
}
