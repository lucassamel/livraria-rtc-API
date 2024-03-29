﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace livraria_rtc.Model
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public int ISNB { get; set; }

        [Required]
        public int Paginas { get; set; }

        [Required]
        public string Genero { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }

    }
}
