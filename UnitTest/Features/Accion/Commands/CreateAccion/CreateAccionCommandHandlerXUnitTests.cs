using Application.Features.Accion.Commands.CreateAccion;
using Application.Mappings;
using AutoMapper;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Models.Models;
using Models.Utils;
using Moq;
using Shouldly;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Features.Accion.Commands.CreateAccion
{
    public class CreateAccionCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateAccionCommandHandlerXUnitTests()
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
        public async Task CrearAccion_Return()
        {
            var CreateAccionInput = new CreateAccionCommand
            {
                DescripcionAccion = "Pepito",
                Estado = false,
                Eliminar = false
            };

            var CreateAccionOutput = new CreateAccionCommandsHandler(_unitOfWork.Object, _mapper);

            var CUresult = await CreateAccionOutput.Handle(CreateAccionInput, CancellationToken.None);

            CUresult.ShouldBeOfType<ApiResponse<string>>();

            Assert.True(CUresult.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
