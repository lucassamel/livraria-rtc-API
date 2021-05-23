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

        [JsonIgnore]
        public ICollection<Livro> Livros { get; set; }

        [JsonIgnore]
        public ICollection<Endereco> Enderecos { get; set; }       

    }
}
