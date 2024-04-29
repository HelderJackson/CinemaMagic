using System.ComponentModel.DataAnnotations;

namespace CinemaMagic.Entidade
{
    public class FilmeEntidade
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Diretor { get; set; }
        public string Duracao { get; set; }
    }
}