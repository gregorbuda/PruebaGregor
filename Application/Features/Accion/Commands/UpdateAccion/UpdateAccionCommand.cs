using MediatR;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Accion.Commands.UpdateAccion
{
    /// <summary>
    ///  Update Accion Command
    /// </summary>
    public class UpdateAccionCommand : IRequest<ApiResponse<bool>>
    {
        /// <summary>
        /// Accion Id
        /// </summary>
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// Accion Description
        /// </summary>
        [Required]
        public string DescripcionAccion { get; set; }
        /// <summary>
        /// Accion State. No Completed: false. Completed: true 
        /// </summary>
        [Required]
        public bool Estado { get; set; }
        /// <summary>
        /// Accion Eliminar. No Completed: false. Completed: true 
        /// </summary>
        [Required]
        public bool Eliminar { get; set; }
    }
}
