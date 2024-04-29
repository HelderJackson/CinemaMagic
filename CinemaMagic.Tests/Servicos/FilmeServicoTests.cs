using CinemaMagic.DataContexto;
using CinemaMagic.Servico;
using CinemaMagic.Tests.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CinemaMagic.Tests.Servicos
{
    public class FilmeServicoTests
    {
        protected readonly AplicacaoDbContexto _contexto;

        public FilmeServicoTests()
        {
            var options = new DbContextOptionsBuilder<AplicacaoDbContexto>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _contexto = new AplicacaoDbContexto(options);

            _contexto.Database.EnsureCreated();
        }

        [Fact]
        public async Task Selecionar_ReturnaColecaoDeFilmes()
        {
            /// Arrange
            _contexto.Filmes.AddRange(FilmesMockDados.Selecionar());
            _contexto.SaveChanges();

            var sut = new FilmeServico(_contexto);

            /// Act
            var result = await sut.Selecionar();

            /// Assert
            result.Should().HaveCount(FilmesMockDados.Selecionar().Count);
        }

        [Fact]
        public async Task Selecionar_Returna()
        {
            /// Arrange
            _contexto.Filmes.AddRange(FilmesMockDados.SelecionarPorID(1));
            _contexto.SaveChanges();

            var sut = new FilmeServico(_contexto);

            /// Act
            var result = await sut.SelecionarPorID(1);

            Assert.Equal(1, result.ID);
        }

        public void Dispose()
        {
            _contexto.Database.EnsureDeleted();
            _contexto.Dispose();
        }
    }
}