using CinemaMagic.Controllers;
using CinemaMagic.Servico;
using CinemaMagic.Tests.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CinemaMagic.Tests.Controller
{
    public class FilmeControllerTests
    {
        [Fact]
        public async Task SelecionarTodos_DeveRetorna200Status()
        {
            /// Arrange
            var filmeServico = new Mock<IFilmeServico>();
            filmeServico.Setup(_ => _.Selecionar()).ReturnsAsync(FilmesMockDados.Selecionar());
            var sut = new FilmeController(filmeServico.Object);
            // Act
            var result = (OkObjectResult)await sut.Selecionar();

            /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task SelecionarPorID_DeveRetorna404Status()
        {
            /// Arrange
            var filmeServico = new Mock<IFilmeServico>();
            filmeServico.Setup(_ => _.SelecionarPorID(1000)).ReturnsAsync(FilmesMockDados.SelecionarPorID(1000));
            var sut = new FilmeController(filmeServico.Object);
            // Act
            var result = (ObjectResult)await sut.SelecionarPorID(1000);

            /// Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task SelecionarTodos_SDeveRetorna204NoContentStatus()
        {
            /// Arrange
            var filmeServico = new Mock<IFilmeServico>();
            filmeServico.Setup(_ => _.Selecionar()).ReturnsAsync(FilmesMockDados.SelecionarVazio());
            var sut = new FilmeController(filmeServico.Object);

            /// Act
            var result = (NoContentResult)await sut.Selecionar();


            /// Assert
            result.StatusCode.Should().Be(204);
            filmeServico.Verify(_ => _.Selecionar(), Times.Exactly(1));
        }

        [Fact]
        public async Task Incluir_NovoFilme_UmaVez()
        {
            /// Arrange
            var filmeService = new Mock<IFilmeServico>();
            var novoFilme = FilmesMockDados.NovoFilme();
            var sut = new FilmeController(filmeService.Object);

            /// Act
            var result = await sut.Incluir(novoFilme);

            /// Assert
            filmeService.Verify(_ => _.Incluir(novoFilme), Times.Exactly(1));
        }

        [Fact]
        public async Task Alterar_Filme_NaoExistenteNoBanco()
        {
            /// Arrange
            var filmeService = new Mock<IFilmeServico>();
            var novoFilme = FilmesMockDados.NovoFilme();
            var alterar = FilmesMockDados.AlterarFilme(novoFilme);
            var sut = new FilmeController(filmeService.Object);

            /// Act
            var result =(ObjectResult) await sut.Alterar(alterar);
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task Excluir_Filme_NaoExistente()
        {
            /// Arrange
            var filmeServico = new Mock<IFilmeServico>();
            var entFilmeExcluido = (FilmesMockDados.Excluir(1000));
            var sut = new FilmeController(filmeServico.Object);
            // Act
            var result = (ObjectResult)await sut.Excluir(entFilmeExcluido);

            /// Assert
            result.StatusCode.Should().Be(404);
        }
    }
}