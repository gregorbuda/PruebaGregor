using MediatR;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Commands.UpdateStatusAccion
{
    /// <summary>
    ///  Update Status Command
    /// </summary>
    public class UpdateStatusAccionCommand : IRequest<ApiResponse<bool>>
    {
        /// <summary>
        /// Accion Id to update status
        /// </summary>
        [Required]
        public string Id { get; set; }
    }
}
