using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace livraria_rtc.Model
{
    public class Endereco
    {
        
        [Key]
        public int EnderecoId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        public string Logadouro { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string Cep { get; set; }

        
        public Usuario Usuario { get; set; }
    }
}
