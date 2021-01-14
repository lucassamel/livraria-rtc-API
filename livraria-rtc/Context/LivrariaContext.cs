using livraria_rtc.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace livraria_rtc.Context
{
    public class LivrariaContext : IdentityDbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options): base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Endereco>()
            //    .HasOne(e => e.Usuario)
            //    .WithMany()                
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<Livro>()
            //    .HasOne(e => e.Usuario)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.NoAction);


        }

    }
}

