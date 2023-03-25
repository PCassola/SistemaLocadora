using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaTeste.Entities
{
    public partial class Clientes
    {
        public Clientes()
        {
            Locacoes = new HashSet<Locacoes>();
        }

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

        [InverseProperty("FK_ClienteNavigation")]
        public virtual ICollection<Locacoes> Locacoes { get; set; }
    }
}
