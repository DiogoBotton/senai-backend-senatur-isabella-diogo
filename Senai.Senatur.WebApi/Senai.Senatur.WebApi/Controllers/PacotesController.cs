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
    public class PacotesController : ControllerBase
    {
        public IPacotesRepository _pacotesRepository;

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
        }
        /// <summary>
        /// Retorna lista de pacotes
        /// </summary>
        /// <returns>Retorna lista pacote</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacotesRepository.Get());
        }
        /// <summary>
        /// Retorna id lista de pacote
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna Id de pacote</returns>
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            var GetId = _pacotesRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Pacote não existe");
            return Ok(_pacotesRepository.BuscarPorId(Id));
        }
        /// <summary>
        /// Cadastra pacote
        /// </summary>
        /// <param name="pacotes"></param>
        /// <returns>Retorna pacote cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Pacotes pacotes)
        {
            _pacotesRepository.Cadastrar(pacotes);

            return StatusCode(201);
        }
        /// <summary>
        /// Atualiza pacote pelo id
        /// </summary>
        /// <param name="pa"></param>
        /// <param name="Id"></param>
        /// <returns>Retorna id de pacote atualizado</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(Pacotes pa, int Id)
        {
            var Pacote = _pacotesRepository.BuscarPorId(Id);
            if (Pacote == null)
                return NotFound("Pacote não encontrado");

            Pacote.AlterarInformacoes(pa.NomePacote, pa.Descricao, pa.DataIda, pa.DataVolta, pa.Valor, pa.Ativo, pa.CidadeId);
            _pacotesRepository.Atualizar(Pacote);
            return Ok(Pacote);
        }
        /// <summary>
        /// Retorna id de pacote deletado
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna id deletado</returns>
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var DeletaPacote = _pacotesRepository.BuscarPorId(Id);
            if (DeletaPacote == null)
                return NotFound("Pacote não foi encontgrado");
            _pacotesRepository.Deletar(DeletaPacote);
            return Ok("Pacote deletado");
        }
        /// <summary>
        /// Retorna pacotes ativos
        /// </summary>
        /// <returns>Retora pacotes ativos</returns>
        [HttpGet("Ativos")]
        public IActionResult Ativos()
        {
            var Ativos = _pacotesRepository.Ativos();
            return Ok(Ativos);
        }
        /// <summary>
        /// Retorna pacotes inativos
        /// </summary>
        /// <returns>Retorna pacotes inativos</returns>
        [HttpGet ("Inativos")]
        public IActionResult Inativos()
        {
            var Inativos = _pacotesRepository.Inativos();
            return Ok(Inativos);
        }
        /// <summary>
        /// Retorna pacotes em crescente
        /// </summary>
        /// <returns>Retorna pacotes em crescente</returns>
        [HttpGet("Asc")]
        public IActionResult Asc()
        {
            return Ok(_pacotesRepository.PorAsc());
        }
        /// <summary>
        /// Retorna pacotes em decrescente
        /// </summary>
        /// <returns>Retorna pacotes em decrescente</returns>
        [HttpGet("Desc")]
        public IActionResult Des()
        {
            return Ok(_pacotesRepository.PorDes());
        }
    }
}
