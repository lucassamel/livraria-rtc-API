using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace livraria_rtc.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }       

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
