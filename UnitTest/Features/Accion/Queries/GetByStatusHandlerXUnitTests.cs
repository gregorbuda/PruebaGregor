using Application.Features.Accion.Queries;
using Application.Mappings;
using AutoMapper;
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

namespace UnitTest.Features.Accion.Queries
{
    public class GetByStatusHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetByStatusHandlerXUnitTests()
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
        public async Task GetByDescripcionAccion_Return()
        {
            var handler = new GetByStatusHandler(_unitOfWork.Object);

            var request = new GetByStatus(true);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<List<AccionTexto>>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
