using CinemaMagic.Entidade;

namespace CinemaMagic.Servico
{
    public interface ISalaServico
    {
        /// <summary>
        /// Inclui um registro de Sala.
        /// </summary>
        /// <param name="entSala">Enidade de Sala</param>
        /// <returns>Um registro incluído.</returns>
        Task Incluir(SalaEntidade entSala);

        /// <summary>
        /// Alteração de um registro de Sala.
        /// </summary>
        /// <param name="entSala">Enidade de Sala</param>
        /// <returns>Um registro alterado de Sala.</returns>
        Task Alterar(SalaEntidade entSala);

        /// <summary>
        /// Exclusão de um registro de Sala.
        /// </summary>
        /// <param name="entSala">ID do Sala que vai ser excluído.</param>
        /// <returns>Retorna a exclusão de um Sala.</returns>
        Task Excluir(int entSala);

        /// <summary>
        /// Seleciona todos as Salas.
        /// </summary>
        /// <returns>Retorna todos as Salas existente na tabela.</returns>
        Task<List<SalaEntidade>> Selecionar();

        /// <summary>
        /// Seleiona a Sala por ID.
        /// </summary>
        /// <param name="salaID">ID da Sala que será selcionado.</param>
        /// <returns>Uma Sala baseado no parâmetro.</returns>
        Task<SalaEntidade> SelecionarPorID(int salaID);

        /// <summary>
        /// Indica se existe uma Sala.
        /// </summary>
        /// <param name="salaID">ID do Filme que será verificado.</param>
        /// <returns>Verdadeiro ou false se existe uma sala.</returns>
        bool ExisteSala(int salaID);

        /// <summary>
        /// Indica se existe um filme.
        /// </summary>
        /// <param name="filmeID">ID do Filme que será verificado.</param>
        /// <returns>Verdadeiro ou false se existe o filme.</returns>
        bool ExisteFilme(int filmeID);

        /// <summary>
        /// Seleciona todas as salas por filme.
        /// </summary>
        /// <param name="filmeID">ID do filme que está passando em determinadas salas.</param>
        /// <returns>Uma lista de salas dependendo do Filme informado.</returns>
        Task<List<SalaEntidade>> SelecionarSalaPorFilme(int filmeID);
    }
}