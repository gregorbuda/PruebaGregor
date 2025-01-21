using Application.Features.Accion.Commands.CreateAccion;
using Application.Features.Accion.Commands.UpdateAccion;
using Application.Mappings;
using AutoMapper;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Models.Utils;
using Moq;
using Shouldly;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Features.Accion.Commands.UpdateAccion
{
    public class UpdateAccionCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateAccionCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AccionProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockAccionRepository.AddDataAccion(_unitOfWork.Object.pruebaTecnicaContext);
        }
        [Fact]
        public async Task UpdateAccion_Return()
        {
            var UpdateAccionInput = new UpdateAccionCommand
            {
                Id = "Ide513cdc3-7bfd-4604-8eb7-fc4715b14d96",
                DescripcionAccion = "Test",
                Estado = false,
                Eliminar = false
            };

            var UpdateAccionOutput = new UpdateAccionCommandHandler(_unitOfWork.Object, _mapper);

            var result = await UpdateAccionOutput.Handle(UpdateAccionInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<bool>>();

            Assert.True(result.CodeResult == StatusCodes.Status404NotFound.ToString());
        }
    }
}

