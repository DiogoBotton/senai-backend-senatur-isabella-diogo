using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        List<Usuarios> Get();
        Usuarios BuscarId(int Id);
        void Cadastrar(Usuarios usuarios);
        void Atualizar(Usuarios usuarios);
        void Deletar(Usuarios usuarios);
        Usuarios BuscarPorNomeSenha(LoginViewModel login);
    }
}
