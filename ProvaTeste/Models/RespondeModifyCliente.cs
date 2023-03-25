using System.ComponentModel.DataAnnotations;

namespace ProvaTeste.Models
{
    public class RespondeModifyCliente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string Sobrenome { get; set; }
        public int? Telefone { get; set; }
        [StringLength(150)]
        public string Endereco { get; set; }
        public bool? Ativacao { get; set; }
    }
}
