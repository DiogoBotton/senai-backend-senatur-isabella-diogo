using Microsoft.AspNetCore.Mvc;
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
    public class TiposUsuariosController : ControllerBase
    {
        public ITiposUsuariosRepository _tiposUsuariosRepository;

        public TiposUsuariosController()
        {
            _tiposUsuariosRepository = new TiposUsuariosRepository();
        }
        /// <summary>
        /// Listar todos tipos de usuários
        /// </summary>
        /// <returns> Retorna lista de tipos usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposUsuariosRepository.Get());
        }
    }
}
