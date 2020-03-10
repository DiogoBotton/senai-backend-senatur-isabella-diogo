using Senai.Senatur.WebApi.Contexts;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();

        public List<Usuarios> Get()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuarios BuscarId(int Id)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Id == Id);
        }

        public void Cadastrar(Usuarios usuarios)
        {
            ctx.Usuarios.Add(usuarios);
            ctx.SaveChanges();
        }

        public void Atualizar(Usuarios usuarios)
        {
            ctx.Usuarios.Update(usuarios);
            ctx.SaveChanges();
        }

        public void Deletar(Usuarios usuarios)
        {
            ctx.Usuarios.Remove(usuarios);
            ctx.SaveChanges();
        }

        public Usuarios BuscarPorNomeSenha(LoginViewModel login)
        {
           return ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            
        }
    }
}
