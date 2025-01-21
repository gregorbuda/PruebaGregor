using MediatR;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Queries
{
    public class GetByDescripcionAccion : IRequest<ApiResponse<List<AccionTexto>>>
    {
        /// <summary>
        /// Description
        /// </summary>
        /// <value>
        /// Description
        /// </value>
        /// <example>Accion</example>

        public string _description { get; set; }

        public GetByDescripcionAccion(string Description)
        {
            _description = Description;
        }
    }
}
