using System.ComponentModel.DataAnnotations;

namespace CinemaMagic.Entidade
{
    public class SalaEntidade
    {
        [Key]
        public int ID { get; set; }
        public int NumeroDaSala { get; set; }
        public string Descricao { get; set; }
        public int FilmeID { get; set; }
    }
}