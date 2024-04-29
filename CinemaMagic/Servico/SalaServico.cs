using CinemaMagic.DataContexto;
using CinemaMagic.Entidade;
using Microsoft.EntityFrameworkCore;

namespace CinemaMagic.Servico
{
    public class SalaServico : ISalaServico
    {
        private readonly AplicacaoDbContexto _context;
        public SalaServico(AplicacaoDbContexto context)
        {
            _context = context;
        }

        public async Task Incluir(SalaEntidade entSala)
        {
            _context.Salas.Add(entSala);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int salaID)
        {
            SalaEntidade sala = _context.Salas.AsNoTracking().FirstOrDefault(s => s.ID == salaID);

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(SalaEntidade entSala)
        {
            try
            {
                SalaEntidade sala = _context.Salas.AsNoTracking().FirstOrDefault(s => s.ID == entSala.ID);

                sala.NumeroDaSala = entSala.NumeroDaSala;
                sala.Descricao = entSala.Descricao;
                sala.FilmeID = entSala.FilmeID;

                _context.Salas.Update(sala);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExisteSala(int salaID)
        {
            return _context.Salas.Any(s => s.ID == salaID);
        }

        public async Task<List<SalaEntidade>> Selecionar()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<SalaEntidade> SelecionarPorID(int salaID)
        {
            SalaEntidade sala = _context.Salas.AsNoTracking().FirstOrDefault(s => s.ID == salaID);

            return sala;
        }

        public async Task<List<SalaEntidade>> SelecionarSalaPorFilme(int filmeID)
        {
            var sala = await _context.Salas.Where(s => s.FilmeID == filmeID).ToListAsync();
            return sala;
        }

        public bool ExisteFilme(int filmeID)
        {
            return _context.Filmes.Any(f => f.ID == filmeID);
        }
    }
}