using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String Nome { get; set; }

        [Required]
        [MaxLength(20)]
        public String Codigo { get; set; }

        [Required]
        [ForeignKey("IdCategoria")]
        public int IdCategoria { get; set; }

    }
}
