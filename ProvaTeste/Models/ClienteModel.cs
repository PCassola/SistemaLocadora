using System.ComponentModel.DataAnnotations;

namespace ProvaTeste.Models
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
