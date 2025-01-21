using MediatR;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Queries
{
    /// <summary>
    ///  Gell all acciones
    /// </summary>
    public class GetAllAccion : IRequest<ApiResponse<List<AccionTexto>>>
    {
    }
}
