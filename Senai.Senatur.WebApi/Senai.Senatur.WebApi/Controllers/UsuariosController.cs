using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuariosRepository _usuariosRepository;

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }
        /// <summary>
        /// Retorna lista de usuários
        /// </summary>
        /// <returns>Retorna lista de todos Usuarios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuariosRepository.Get());
        }
        /// <summary>
        /// Retorna o usuário buscado, por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna o usuário buscado pelo Id passado</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            var GetId = _usuariosRepository.BuscarId(Id);
            if (GetId == null)
                return NotFound("Usuario não encontrado");
            return Ok(_usuariosRepository.BuscarId(Id));
        }
        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuarios"></param>
        /// <returns>Retorna usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Usuarios usuarios)
        {
            _usuariosRepository.Cadastrar(usuarios);

            return StatusCode(201);
        }
        /// <summary>
        /// Atualiza o usuário, pelo id passado
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="Id"></param>
        /// <returns>Retorna o id de usuário cadastrado</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(Usuarios usuarios, int Id)
        {
            var AtualizaUsuario = _usuariosRepository.BuscarId(Id);
            if (AtualizaUsuario == null)
                return NotFound("Não encontrado usuário");

            AtualizaUsuario.AlterarInformacoes(usuarios.Email, usuarios.Senha, usuarios.TiposUsuariosId);
            _usuariosRepository.Atualizar(AtualizaUsuario);
            return Ok(AtualizaUsuario);
        }
        /// <summary>
        /// Deleta o usuário passando o seu Id
        /// </summary>
        /// <param name="usuarios"></param>
        /// <param name="Id"></param>
        /// <returns>Retorna o Id do usuário deletado</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(Usuarios usuarios, int Id)
        {
            var DeletaUsuario = _usuariosRepository.BuscarId(Id);
            if (DeletaUsuario == null)
                return NotFound("Usuario não encontrado");

            _usuariosRepository.Atualizar(DeletaUsuario);
            return Ok("Usuario deletado");
        }

    }
}
