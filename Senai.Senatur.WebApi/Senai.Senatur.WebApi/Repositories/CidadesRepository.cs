using Senai.Senatur.WebApi.Contexts;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class CidadesRepository : ICidadesRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void Cadastrar(Cidades cidades)
        {
            ctx.Cidades.Add(cidades);
            ctx.SaveChanges();
        }

        public List<Cidades> Get()
        {
            return ctx.Cidades.ToList();
        }
    }
}
