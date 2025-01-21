using MediatR;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Seguridad
{
    public class LoginCommands : IRequest<ApiResponse<string>>
    {
        /// <summary>
        /// Email User
        /// </summary>
        /// <value>
        /// Email User
        /// </value>
        /// <example>test@test.com</example>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Password User
        /// </summary>
        /// <value>
        /// Password User
        /// </value>
        /// <example></example>
        [Required]
        public string? Password { get; set; }
        /// <summary>
        /// Role User
        /// </summary>
        /// <value>
        /// Role User
        /// </value>
        /// <example></example>
        [Required]
        public string? Role { get; set; }
    }
}
