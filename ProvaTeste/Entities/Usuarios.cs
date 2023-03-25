using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaTeste.Entities
{
    public partial class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Login { get; set; }
        [StringLength(50)]
        public string Senha { get; set; }
    }
}
