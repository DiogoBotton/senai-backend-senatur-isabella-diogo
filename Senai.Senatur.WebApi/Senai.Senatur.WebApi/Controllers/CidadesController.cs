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
    public class CidadesController : ControllerBase
    {
        public ICidadesRepository _cidadesRepository;

        public CidadesController()
        {
            _cidadesRepository = new CidadesRepository();
        }
        /// <summary>
        /// Retorna lista de todas cidades
        /// </summary>
        /// <returns>Retorna lista de cidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cidadesRepository.Get());
        }
        /// <summary>
        /// Cadastra uma cidade
        /// </summary>
        /// <param name="cidades"></param>
        /// <returns>Retorna cidade cadastrada</returns>
        [HttpPost]
        public IActionResult Post(Cidades cidades)
        {
            _cidadesRepository.Cadastrar(cidades);
            return StatusCode(201);
        }
    }
}
