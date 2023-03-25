using System.ComponentModel.DataAnnotations;

namespace ProvaTeste.Models
{
    public class FilmeModel
    {
        public string Nome { get; set; }
        [StringLength(50)]
        public string Diretor { get; set; }
        [StringLength(255)]
        public string Sinopsia { get; set; }
        public int? Situacao { get; set; }
    }
}