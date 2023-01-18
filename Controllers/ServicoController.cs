using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Dto;
using SistemaVendas.Models;
using SistemaVendas.Repository;

namespace SistemaVendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _repository;

        public ServicoController(ServicoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarServicoDTO dto)
        {
            var servico = new Servico(dto);
            _repository.Cadastrar(servico);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                var servicoDTO = new ObterServicoDTO(servico);
                return Ok(servicoDTO);
            }
            else 
                return NotFound(new { Mensagem = "Serviço não encontrado."});
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var servicos = _repository.ObterPorNome(nome);
            return Ok(servicos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                servico.MapearAtualizarServicoDTO(dto);
                _repository.AtualizarServico(servico);
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Serviço não encontrado."});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var servico = _repository.ObterPorId(id);
            if(servico is not null)
            {
                _repository.DeletarServico(servico);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Serviço não encontrado."});
            }
        }
    }
}