using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Context;
using SistemaVendas.Dto;
using SistemaVendas.Models;

namespace SistemaVendas.Repository
{
    public class ItensPedidoRepository
    {
        private readonly VendasContext _context;

        public ItensPedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public ItensPedido Cadastrar(ItensPedido itensPedido)
        {
            _context.ItensPedido.Add(itensPedido);
            _context.SaveChanges();

            return itensPedido;
        }

        public ItensPedido ObterPorId(int id)
        {
            var itensPedido = _context.ItensPedido.Include(x => x.Pedido)
                                        .Include(x=> x.Servico)
                                        .FirstOrDefault(x => x.Id == id);
            return itensPedido;
        }
        public ItensPedido AtualizarItensPedido(ItensPedido itensPedido)
        {
            _context.ItensPedido.Update(itensPedido);
            _context.SaveChanges();

            return itensPedido;
        }

        public void DeletarItensPedido(ItensPedido itensPedido)
        {
            _context.ItensPedido.Remove(itensPedido);
            _context.SaveChanges();
        }
    }
}