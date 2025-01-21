using MediatR;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Commands.UpdateEliminarAccion
{
    /// <summary>
    ///  Update Delete Status Command
    /// </summary>
    public class UpdateEliminarAccionCommand : IRequest<ApiResponse<bool>>
    {
        /// <summary>
        /// Accion Id to update delete status
        /// </summary>
        [Required]
        public string Id { get; set; }
    }
}
