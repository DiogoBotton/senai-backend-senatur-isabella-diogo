using Senai.Senatur.WebApi.Contexts;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void Atualizar(Pacotes pacotes)
        {
            ctx.Pacotes.Update(pacotes);
            ctx.SaveChanges();
        }

        public Pacotes BuscarPorId(int Id)
        {
            return ctx.Pacotes.FirstOrDefault(x => x.Id == Id);
        }

        public void Cadastrar(Pacotes pacotes)
        {
            ctx.Pacotes.Add(pacotes);
            ctx.SaveChanges();
        }

        public void Deletar(Pacotes pacotes)
        {
            ctx.Pacotes.Remove(pacotes);
            ctx.SaveChanges();
        }

        public List<Pacotes> Get()
        {
            return ctx.Pacotes.ToList();
        }


    }
}
