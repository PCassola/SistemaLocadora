using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProvaTeste.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProvaTeste.Models
{
    public class LocacaoModel
    {
        public int id { get; set; }
        public int idFilme { get; set; }
        public int idCliente { get; set; }

        public DateTime? Data_Locacao { get; set; }
        public int? Situacao { get; set; }

        [Required]
        public int? ValorDiaria { get; set; }

    }
}
