using Application.Features.Accion.Commands.UpdateEliminarAccion;
using Application.Features.Accion.Commands.UpdateStatusAccion;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Models.Utils;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Features.Accion.Commands.UpdateStatusAccion
{
    public class UpdateStatusAccionCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateStatusAccionCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            MockAccionRepository.AddDataAccion(_unitOfWork.Object.pruebaTecnicaContext);
        }
        [Fact]
        public async Task UpdateAccionStatus_Return()
        {
            var UpdateAccionInput = new UpdateStatusAccionCommand
            {
                Id = "Ide513cdc3-7bfd-4604-8eb7-fc4715b14d96",
            };

            var UpdateAccionOutput = new UpdateStatusAccionCommandHandler(_unitOfWork.Object);

            var result = await UpdateAccionOutput.Handle(UpdateAccionInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<bool>>();

            Assert.True(result.CodeResult == StatusCodes.Status404NotFound.ToString());
        }
    }
}
