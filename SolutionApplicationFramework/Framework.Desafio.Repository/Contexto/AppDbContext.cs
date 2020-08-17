using System;
using Framework.Desafio.Model.Entidade;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Framework.Desafio.Repository.Contexto
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        { }

        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }

    }
}
