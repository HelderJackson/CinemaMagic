using CinemaMagic.Entidade;

namespace CinemaMagic.Servico
{
    public interface IFilmeServico
    {
        /// <summary>
        /// Inclui um registro de Filme.
        /// </summary>
        /// <param name="entFilme">Enidade de Filme</param>
        /// <returns>Um registro incluído.</returns>
        Task Incluir(FilmeEntidade entFilme);

        /// <summary>
        /// Alteração de um registro de Filme.
        /// </summary>
        /// <param name="entFilme">Enidade de Filme</param>
        /// <returns>Um registro alterado de filme.</returns>
        Task Alterar(FilmeEntidade entFilme);

        /// <summary>
        /// Exclusão de um registro de Filme.
        /// </summary>
        /// <param name="filmeID">ID do Filme que vai ser excluído.</param>
        /// <returns>Retorna a exclusão de um FIlme.</returns>
        Task Excluir(int filmeID);

        /// <summary>
        /// Seleciona todos os Filmes.
        /// </summary>
        /// <returns>Retorna todos os filmes existente na tabela.</returns>
        Task<List<FilmeEntidade>> Selecionar();

        /// <summary>
        /// Seleiona o Filme por ID.
        /// </summary>
        /// <param name="filmeID">ID do Filme que será selcionado.</param>
        /// <returns>Um Filme baseado no parâmetro.</returns>
        Task <FilmeEntidade> SelecionarPorID(int filmeID);

        /// <summary>
        /// Indica se existe um filme.
        /// </summary>
        /// <param name="filmeID">ID do Filme que será verificado.</param>
        /// <returns>Verdadeiro ou false se existe o filme.</returns>
        bool ExisteFilme(int filmeID);    
    }
}