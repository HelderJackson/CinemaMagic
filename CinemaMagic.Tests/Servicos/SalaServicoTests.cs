using CinemaMagic.DataContexto;
using CinemaMagic.Servico;
using CinemaMagic.Tests.MockData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CinemaMagic.Tests.Servicos
{
    public  class SalaServicoTests
    {
        protected readonly AplicacaoDbContexto _contexto;

        public SalaServicoTests()
        {
            var options = new DbContextOptionsBuilder<AplicacaoDbContexto>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _contexto = new AplicacaoDbContexto(options);

            _contexto.Database.EnsureCreated();
        }

        [Fact]
        public async Task Selecionar_ReturnaColecaoDeSala()
        {
            /// Arrange
            _contexto.Salas.AddRange(SalaMockDados.Selecionar());
            _contexto.SaveChanges();

            var sut = new SalaServico(_contexto);

            /// Act
            var result = await sut.Selecionar();

            /// Assert
            result.Should().HaveCount(SalaMockDados.Selecionar().Count);
        }

        [Fact]
        public async Task Selecionar_Returna()
        {
            /// Arrange
            _contexto.Salas.AddRange(SalaMockDados.SelecionarPorID(1));
            _contexto.SaveChanges();

            var sut = new SalaServico(_contexto);

            var result = await sut.SelecionarPorID(1);
            /// Assert
            Assert.Equal(1, result.ID);
        }

        public void Dispose()
        {
            _contexto.Database.EnsureDeleted();
            _contexto.Dispose();
        }
    }
}