using MediatR;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Queries
{
    public class GetByStatus : IRequest<ApiResponse<List<AccionTexto>>>
    {
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>

        public bool _status { get; set; }

        public GetByStatus(bool Status)
        {
            _status = Status;
        }
    }
}
