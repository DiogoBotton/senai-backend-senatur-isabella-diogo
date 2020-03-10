using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Contexts
{
    public class SenaturContext : DbContext
    {
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public DbSet<Cidades> Cidades { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pacotes> Pacotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DEV1\\SQLEXPRESS; initial catalog=Senatur_Tarde; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO: FAZER IMPLEMENTAÇÃO DE REGISTROS PEDIDOS NA DA DOCUMENTAÇÃO
            builder.Entity<TiposUsuarios>();

            builder.Entity<Cidades>();

            builder.Entity<Usuarios>();

            builder.Entity<Pacotes>();
        }
    }
}
