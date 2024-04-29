using CinemaMagic.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMagic.Tests.MockData
{
    public  class SalaMockDados
    {
        public static List<SalaEntidade> Selecionar()
        {
            return new List<SalaEntidade>{
                new SalaEntidade{
                    ID = 1,
                    NumeroDaSala = 1,
                    FilmeID = 1,
                    Descricao = "SALA 1 "
                },
                new SalaEntidade{
                    ID = 2,
                    NumeroDaSala = 2,
                    FilmeID = 1,
                    Descricao = "SALA 2 "
                },
                new SalaEntidade{
                    ID = 3,
                    NumeroDaSala = 3,
                    FilmeID = 1,
                    Descricao = "SALA 3"
                }
            };
        }

        public static SalaEntidade SelecionarPorID(int salaID)
        {
            return new SalaEntidade
            {
                ID = salaID,
                NumeroDaSala = 3,
                FilmeID = 1,
                Descricao = "SALA 3"
            };
        }

        public static int Excluir(int filmeID)
        {
            return filmeID;
        }

        public static List<SalaEntidade> SelecionarVazio()
        {
            return new List<SalaEntidade>();
        }

        public static FilmeEntidade NovoFilme()
        {
            return new FilmeEntidade
            {
                ID = 4,
                Nome  = "Matrix",
                Diretor = "WAT",
                Duracao = "30 MIN"
            };
        }

        public static SalaEntidade NovaSala()
        {
            return new SalaEntidade
            {
                ID = 4,
                NumeroDaSala = 3,
                FilmeID = 1,
                Descricao = "SALA 3"
            };
        }

        public static SalaEntidade NovaSala(FilmeEntidade entFilme)
        {
            return new SalaEntidade
            {
                ID = 4,
                NumeroDaSala = 3,
                FilmeID = entFilme.ID,
                Descricao = "SALA 3"
            };
        }

        public static SalaEntidade AlterarSala(SalaEntidade entSala)
        {
            var entSala_alterada = new SalaEntidade
            {
                ID = 4,
                NumeroDaSala = 4,
                FilmeID = 1,
                Descricao = "SALA 4"
            };

            return entSala_alterada;
        }
    }
}