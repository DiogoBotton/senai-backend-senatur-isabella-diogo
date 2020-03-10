using Senai.Senatur.WebApi.Contexts;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();
        /// <summary>
        /// Lista todos usuários
        /// </summary>
        /// <returns>Retorna a lista de usuários</returns>
        public List<TiposUsuarios> Get()
        {
            //Retorna lista com usuários
            return ctx.TiposUsuarios.ToList();
        }
    }
}
