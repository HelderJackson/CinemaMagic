using CinemaMagic.Entidade;

namespace CinemaMagic.Tests.MockData
{
    public class FilmesMockDados
    {
        public static List<FilmeEntidade> Selecionar()
        {
            return new List<FilmeEntidade>{
                new FilmeEntidade{
                    ID = 1,
                    Nome = "Matrix",
                    Diretor = "Lilly Wachowski\r\nLana Wachowski",
                    Duracao = "100 min"
                },
                new FilmeEntidade{
                    ID = 2,
                    Nome = "Matrix 2",
                    Diretor = "Lilly Wachowski\r\nLana Wachowski",
                    Duracao = "96 min"
                },
                new FilmeEntidade{
                    ID = 3,
                    Nome = "Matrix 3",
                    Diretor = "Lilly Wachowski\r\nLana Wachowski",
                    Duracao = "120 min"
                }
            };
        }

        public static FilmeEntidade SelecionarPorID(int filmeID)
        {
            return new FilmeEntidade{
                    ID = filmeID,
                    Nome = "Matrix",
                    Diretor = "Lilly Wachowski\r\nLana Wachowski",
                    Duracao = "100 min"
                };
        }

        public static int Excluir(int filmeID)
        {
            return filmeID;
        }

        public static List<FilmeEntidade> SelecionarVazio()
        {
            return new List<FilmeEntidade>();
        }

        public static FilmeEntidade NovoFilme()
        {
            return new FilmeEntidade
            {
                ID = 4,
                Nome = "Matrix",
                Diretor = "Lilly Wachowski\r\nLana Wachowski",
                Duracao = "120 min"
            };
        }

        public static FilmeEntidade AlterarFilme(FilmeEntidade entFilme)
        {
            var entFilme_alterada = new FilmeEntidade
            {
                ID = 4,
                Nome = "Star Wars",
                Diretor = "Lucas",
                Duracao = "120 min"
            };

            return entFilme_alterada;
        }
    }
}