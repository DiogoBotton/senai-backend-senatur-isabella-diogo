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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacotesRepository.Get());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            var GetId = _pacotesRepository.BuscarPorId(Id);
            if (GetId == null)
                return NotFound("Pacote não existe");
            return Ok(_pacotesRepository.BuscarPorId(Id));
        }

        [HttpPost]
        public IActionResult Post(Pacotes pacotes)
        {
            _pacotesRepository.Cadastrar(pacotes);

            return StatusCode(201);
        }

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

        [HttpDelete("{Id}")]
        public IActionResult Deletar(Pacotes pa, int Id)
        {
            var DeletaPacote = _pacotesRepository.BuscarPorId(Id);
            if (DeletaPacote == null)
                return NotFound("Pacote não foi encontgrado");
            _pacotesRepository.Deletar(DeletaPacote);
            return Ok("Pacote deletado");
        }

        [HttpGet("Ativos")]
        public IActionResult Ativos()
        {
            var Ativos = _pacotesRepository.Ativos();
            return Ok(Ativos);
        }

        [HttpGet ("Inativos")]
        public IActionResult Inativos()
        {
            var Inativos = _pacotesRepository.Inativos();
            return Ok(Inativos);
        }

        [HttpGet("Asc")]
        public IActionResult Asc()
        {
            return Ok(_pacotesRepository.PorAsc());
        }

        [HttpGet("Desc")]
        public IActionResult Des()
        {
            return Ok(_pacotesRepository.PorDes());
        }
    }
}
