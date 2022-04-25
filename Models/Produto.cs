using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCrud.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { set; get; }
        
        [Required]
        [Column("nome")]
        public string Nome { set; get; }
        
        [Required]
        [Column("preco")]
        public float Preco { set; get; }
        
        public Produto()
        {
        }

        public Produto(int id, string nome, float preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return Id + "," + Nome + "," + Preco;
        }
    }
}
