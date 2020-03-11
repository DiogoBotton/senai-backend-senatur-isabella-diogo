using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
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
                //optionsBuilder.UseSqlServer("Data Source=DEV1\\SQLEXPRESS; initial catalog=Senatur_Tarde; user Id=sa; pwd=sa@132;");
                optionsBuilder.UseSqlServer("Data Source=DEV16\\SQLEXPRESS; initial catalog=Senatur_Tarde; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO: FAZER IMPLEMENTAÇÃO DE REGISTROS PEDIDOS NA DA DOCUMENTAÇÃO
            builder.Entity<TiposUsuarios>().HasData(new TiposUsuarios
            {
                Id = 1,
                Titulo = "Administrador"
            },
            new TiposUsuarios
            {
                Id = 2,
                Titulo = "Comum"
            });

            builder.Entity<Cidades>().HasData(new Cidades
            {
                Id = 1,
                Titulo = "Salvador"
            },
            new Cidades
            {
                Id = 2,
                Titulo = "Bonito"
            });

            builder.Entity<Usuarios>().HasData(new Usuarios
            {
                Id = 1,
                Email = "admin@admin.com",
                Senha = "admin",
                TiposUsuariosId = 1
            },
            new Usuarios
            {
                Id = 2,
                Email = "cliente@cliente.com",
                Senha = "cliente",
                TiposUsuariosId = 2,
            }
            );

            builder.Entity<Pacotes>().HasData(new Pacotes
            {
                Id = 1,
                NomePacote = "SALVADOR - 5 DIAS / 4 DIÁRIAS",
                Descricao = "O que não falta em Salvador são atrações. " +
                "Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região." +
                "A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos " +
                "mais procurados por turistas brasileiros e estrangeiros.O Pelourinho e o Elevador são alguns dos principais pontos de visitação.",
                DataIda = Convert.ToDateTime("06/08/2020"),
                DataVolta = Convert.ToDateTime("10/08/2020"),
                Valor = 854,
                CidadeId = 1,
                Ativo = true
            },
            new Pacotes()
            {
                Id = 2,
                NomePacote = "RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS",
                Descricao = "- O Litoral Norte da Bahia conta com" +
                "inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas" +
                "que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em" +
                "águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões," +
                "passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas" +
                "estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí," +
                "Praia do Forte e Costa do Sauipe.",
                DataIda = Convert.ToDateTime("14/05/2020"),
                DataVolta = Convert.ToDateTime("18/08/2020"),
                Valor = 1826,
                CidadeId = 1,
                Ativo = true
            },
            new Pacotes()
            {
                Id = 3,
                NomePacote = "BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS",
                Descricao = "Localizado no estado de Mato Grosso do" +
                "Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas" +
                "cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes." +
                "Os aventureiros costumam render-se facilmente a esse destino regado por trilhas" +
                "ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas d'água da" +
                "região.",
                DataIda = Convert.ToDateTime("28/03/2020"),
                DataVolta = Convert.ToDateTime("01/04/2020"),
                Valor = 1004,
                CidadeId = 2,
                Ativo = true
            });
        }
    }
}
