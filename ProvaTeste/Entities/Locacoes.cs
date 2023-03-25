using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaTeste.Entities
{
    public partial class Locacoes
    {
        [Key]
        public int id { get; set; }
        public int? FK_Filme { get; set; }
        public int? FK_Cliente { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Data_Locacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Data_Devolucao { get; set; }
        public int? Situacao { get; set; }
        public int? ValorDiaria { get; set; }
        [Required]
        public int? ValorPagar { get; set; }

        [ForeignKey(nameof(FK_Cliente))]
        [InverseProperty(nameof(Clientes.Locacoes))]
        public virtual Clientes FK_ClienteNavigation { get; set; }
        [ForeignKey(nameof(FK_Filme))]
        [InverseProperty(nameof(Filmes.Locacoes))]
        public virtual Filmes FK_FilmeNavigation { get; set; }
    }
}
