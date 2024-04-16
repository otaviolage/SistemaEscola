using AutoFixture;
using Moq;
using SistemaEscola.Domain.DTOs;
using SistemaEscola.Domain.Interfaces.Repositories;
using SistemaEscola.Domain.Services;

namespace SistemaEscola.Tests.Domain.Services
{
    public class AlunoServiceTest
    {
        private readonly AlunoService _orderService;
        private readonly Mock<IAlunoRepository> _mockAlunoRepository;
        private readonly Fixture _factory = new();

        public AlunoServiceTest()
        {
            _mockAlunoRepository = new();

            _orderService = new(_mockAlunoRepository.Object);
        }

        [Fact]
        public void GetAll_ShouldReturnAllAlunos()
        {
            var listaDeAlunos = _factory.Create<IEnumerable<AlunoDTO>>();

            _mockAlunoRepository.Setup(x => x.GetAll())
                .ReturnsAsync(listaDeAlunos);

            var result = _orderService.GetAll().Result;

            Assert.Equal(listaDeAlunos.Count(), result.Count());

            for (int i = 0; i < result.Count(); i++)
            {
                Assert.Equal(listaDeAlunos.ElementAt(i).Id, result.ElementAt(i).Id);
                Assert.Equal(listaDeAlunos.ElementAt(i).Nome, result.ElementAt(i).Nome);
                Assert.Equal(listaDeAlunos.ElementAt(i).Usuario, result.ElementAt(i).Usuario);
                Assert.Equal(listaDeAlunos.ElementAt(i).Senha, result.ElementAt(i).Senha);
            }

            _mockAlunoRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}