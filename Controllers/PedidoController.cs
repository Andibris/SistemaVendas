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
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _repository;
        public PedidoController(PedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarPedidoDTO dto)
        {
            var pedido = new Pedido(dto);
            _repository.Cadastrar(pedido);
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var pedido = _repository.ObterPorId(id);
            if(pedido is not null)
            {
                return Ok(pedido);
            }
            else
            {
                return NotFound(new {Mensagem = "Pedido não encontrado."});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarPedidoDTO dto)
        {
            var pedido = _repository.ObterPorId(id);

            if(pedido is not null)
            {
                pedido.MapearAtualizarPedidoDTO(dto);
                _repository.AtualizarPedido(pedido);
                return Ok(pedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Pedido não encontrado."});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var pedido = _repository.ObterPorId(id);
            if(pedido is not null)
            {
                _repository.DeletarPedido(pedido);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Pedido não encontrado."});
            }
        }
    }
}