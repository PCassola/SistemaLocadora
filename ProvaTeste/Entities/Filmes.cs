using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaTeste.Entities
{
    public partial class Filmes
    {
        public Filmes()
        {
            Locacoes = new HashSet<Locacoes>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string Diretor { get; set; }
        [StringLength(255)]
        public string Sinopsia { get; set; }
        public int? Situacao { get; set; }

        [InverseProperty("FK_FilmeNavigation")]
        public virtual ICollection<Locacoes> Locacoes { get; set; }
    }
}
