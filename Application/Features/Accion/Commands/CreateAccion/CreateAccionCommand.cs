using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Utils;

namespace Application.Features.Accion.Commands.CreateAccion
{
    /// <summary>
    ///  Create Accion Command
    /// </summary>
    public class CreateAccionCommand : IRequest<ApiResponse<string>>
    {
        /// <summary>
        /// Indica la acción en si
        /// </summary>
        [Required]
        public string DescripcionAccion { get; set; }
        /// <summary>
        /// Accion State. No Completed: false. Completed: true 
        /// </summary>
        [Required]
        [DefaultValue(false)]
        public bool Estado { get; set; } = false;
        /// <summary>
        /// Accion Eliminar. No Completed: false. Completed: true 
        /// </summary>
        [Required]
        [DefaultValue(false)]
        public bool Eliminar { get; set; } = false;

    }
}
