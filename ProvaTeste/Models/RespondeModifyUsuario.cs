using System.ComponentModel.DataAnnotations;

namespace ProvaTeste.Models
{
    public class RespondeModifyUsuario
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Login { get; set; }
        [StringLength(50)]
        public string Senha { get; set; }
    }
}
