using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;
using Senai.Senatur.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUsuariosRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Fazer Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Token do Usuário</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var retorno = _usuarioRepository.BuscarPorNomeSenha(login);

            if (retorno == null)
                return NotFound("Usuário e/ou senha incorretos.");

            var informacoesUsuario = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, retorno.Email),
                new Claim(JwtRegisteredClaimNames.Jti, retorno.Id.ToString()),
                new Claim(ClaimTypes.Role, retorno.TiposUsuariosId.ToString())
            };

            //Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senatur-chave-autentificacao"));

            //Define as credenciais do token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Gera o token
            var token = new JwtSecurityToken(
                issuer: "Senai.Senatur.WebApi",
                audience: "Senai.Senatur.WebApi",
                claims: informacoesUsuario,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
