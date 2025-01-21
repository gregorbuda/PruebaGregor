using Application.Features.Accion.Commands.UpdateAccion;
using Application.Features.Accion.Commands.UpdateEliminarAccion;
using Application.Mappings;
using AutoMapper;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Models.Utils;
using Moq;
using Shouldly;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Features.Accion.Commands.UpdateEliminarAccion
{
    public class UpdateEliminarAccionCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateEliminarAccionCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            MockAccionRepository.AddDataAccion(_unitOfWork.Object.pruebaTecnicaContext);
        }
        [Fact]
        public async Task UpdateAccionStatusEliminar_Return()
        {
            var UpdateAccionInput = new UpdateEliminarAccionCommand
            {
                Id = "Ide513cdc3-7bfd-4604-8eb7-fc4715b14d96",
            };

            var UpdateAccionOutput = new UpdateEliminarAccionCommandHandler(_unitOfWork.Object);

            var result = await UpdateAccionOutput.Handle(UpdateAccionInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<bool>>();

            Assert.True(result.CodeResult == StatusCodes.Status404NotFound.ToString());
        }
    }
}
