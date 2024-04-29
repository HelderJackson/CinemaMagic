using CinemaMagic.Controllers;
using CinemaMagic.Servico;
using CinemaMagic.Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CinemaMagic.Tests.Controller
{
    public class SalaControllerTests
    {
        [Fact]
        public async Task SelecionarTodos_DeveRetorna200Status()
        {
            /// Arrange
            var salaServico = new Mock<ISalaServico>();
            salaServico.Setup(_ => _.Selecionar()).ReturnsAsync(SalaMockDados.Selecionar());
            var sut = new SalaController(salaServico.Object);
            // Act
            var result = (OkObjectResult)await sut.Selecionar();

            /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task SelecionarPorID_DeveRetorna404Status()
        {
            /// Arrange
            var salaServico = new Mock<ISalaServico>();
            salaServico.Setup(_ => _.SelecionarPorID(1000)).ReturnsAsync(SalaMockDados.SelecionarPorID(1000));
            var sut = new SalaController(salaServico.Object);
            // Act
            var result = (ObjectResult)await sut.SelecionarPorID(1000);

            /// Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task SelecionarTodos_SDeveRetorna204NoContentStatus()
        {
            /// Arrange
            var salaServico = new Mock<ISalaServico>();
            salaServico.Setup(_ => _.Selecionar()).ReturnsAsync(SalaMockDados.SelecionarVazio());
            var sut = new SalaController(salaServico.Object);

            /// Act
            var result = (NoContentResult)await sut.Selecionar();


            /// Assert
            result.StatusCode.Should().Be(204);
            salaServico.Verify(_ => _.Selecionar(), Times.Exactly(1));
        }

        [Fact]
        public async Task Alterar_Sala_NaoExistenteNoBanco()
        {
            /// Arrange
            var salaServico = new Mock<ISalaServico>();
            var novaSala = SalaMockDados.NovaSala();
            var alterar = SalaMockDados.AlterarSala(novaSala);
            var sut = new SalaController(salaServico.Object);

            /// Act
            var result = (ObjectResult)await sut.Alterar(alterar);
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Excluir_Sala_NaoExistente()
        {
            /// Arrange
            var salaServico = new Mock<ISalaServico>();
            var entSalaExcluido = (SalaMockDados.Excluir(1000));
            var sut = new SalaController(salaServico.Object);
            // Act
            var result = (ObjectResult)await sut.Excluir(entSalaExcluido);

            /// Assert
            result.StatusCode.Should().Be(404);
        }
    }
}
