using livraria_rtc.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria_rtc.Context
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options): base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<livraria_rtc.Model.Usuario> Usuario { get; set; }

        public DbSet<livraria_rtc.Model.Endereco> Endereco { get; set; }
                

    }
}

