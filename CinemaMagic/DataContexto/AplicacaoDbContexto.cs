using CinemaMagic.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CinemaMagic.DataContexto
{
    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> options) : base(options){ }

        public DbSet<FilmeEntidade>? Filmes { get; set; }
        public DbSet<SalaEntidade>? Salas { get; set; }
    }
}