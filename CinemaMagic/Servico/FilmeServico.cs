using CinemaMagic.DataContexto;
using CinemaMagic.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CinemaMagic.Servico
{
    public class FilmeServico : IFilmeServico
    {
        private readonly AplicacaoDbContexto _context;
        public FilmeServico(AplicacaoDbContexto context)
        {
            _context = context;
        }

        public async Task Incluir(FilmeEntidade entFilme)
        {
            _context.Filmes.Add(entFilme);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(FilmeEntidade entFilme)
        {
            try
            {
                FilmeEntidade filme = _context.Filmes.AsNoTracking().FirstOrDefault(f => f.ID == entFilme.ID);

                filme.Nome = entFilme.Nome;
                filme.Diretor = entFilme.Diretor;
                filme.Duracao = entFilme.Duracao;

                _context.Filmes.Update(filme);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Excluir(int filmeID)
        {
            FilmeEntidade filme = _context.Filmes.AsNoTracking().FirstOrDefault(f => f.ID == filmeID);

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FilmeEntidade>> Selecionar()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<FilmeEntidade> SelecionarPorID(int filmeID)
        {
            FilmeEntidade filme = _context.Filmes.AsNoTracking().FirstOrDefault(f => f.ID == filmeID);

            return filme;
        }

        public bool ExisteFilme(int creditoID)
        {
            return _context.Filmes.Any(c => c.ID == creditoID);
        }
    }
}