using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Dto
{
    public class ObterItensPedidoDTO
    {
        
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ServicoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        
        public ObterItensPedidoDTO(ItensPedido itensPedido)
        {
            Id = itensPedido.Id;
            PedidoId = itensPedido.PedidoId;
            ServicoId = itensPedido.ServicoId;
            Quantidade = itensPedido.Quantidade;
            Valor = itensPedido.Valor;
        }
    }
}