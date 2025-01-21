using Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Seguridad
{
    public class LoginCommandsHandler : IRequestHandler<LoginCommands, ApiResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginCommandsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<string>> Handle(LoginCommands request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            String token = "";
            try
            {
                var result = await _unitOfWork.userRepository.GetToken(request.Email, request.Password);

                if (result)
                {
                    token = Security.Security.GenerateToken(request.Email, request.Role);
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Login succesful";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "Login Failed";
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Error interno del servidor";
                success = false;
            }

            ApiResponse<string> response = new ApiResponse<string>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = token,
                Success = success
            };

            return response;
        }
    }
}
