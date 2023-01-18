using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;

namespace SistemaVendas.Dto
{
    public class ObterPedidoDTO
    {
        
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        
        public ObterPedidoDTO(Pedido pedido)
        {
            Data = pedido.Data;
            VendedorId = pedido.VendedorId;
            Vendedor = pedido.Vendedor;
            ClienteID = pedido.ClienteID;
            Cliente = pedido.Cliente;
        }
    }
}