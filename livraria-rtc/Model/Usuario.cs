using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace livraria_rtc.Model
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }        

        // public ICollection<Livro> Livros { get; set; }
        // public ICollection<Endereco> Enderecos { get; set; }

        public Livro Livro { get; set; }
        
        public Endereco Endereco { get; set; }

    }
}
