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
    public class ItensPedidoController : ControllerBase
    {
        private readonly ItensPedidoRepository _repository;
        public ItensPedidoController(ItensPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarItensPedidoDTO dto)
        {
            var itensPedido = new ItensPedido(dto);
            _repository.Cadastrar(itensPedido);
            return Ok(itensPedido);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var itensPedido = _repository.ObterPorId(id);
            if(itensPedido is not null)
            {
                return Ok(itensPedido);
            }
            else
            {
                return NotFound(new {Mensagem = "Item de pedido não encontrado."});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarItensPedidoDTO dto)
        {
            var itensPedido = _repository.ObterPorId(id);

            if(itensPedido is not null)
            {
                itensPedido.MapearAtualizarItensPedidoDTO(dto);
                _repository.AtualizarItensPedido(itensPedido);
                return Ok(itensPedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Item de pedido não encontrado."});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var itensPedido = _repository.ObterPorId(id);
            if(itensPedido is not null)
            {
                _repository.DeletarItensPedido(itensPedido);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Item de pedido não encontrado."});
            }
        }
    }
}