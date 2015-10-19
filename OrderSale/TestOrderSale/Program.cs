using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestOrderSale
{
    class Program
    {
        static List<Produto> produtos = null;
        static List<Pedido> pedidos = null;

        static void Main(string[] args)
        {
            var pedidoDAL = new PedidoDAL();
            var produtoDAL = new ProdutoDAL();
            var clienteDAL = new ClienteDAL();

            InsertProdutos(produtoDAL);
            InsertPedidos(pedidoDAL);
            InsertCliente(clienteDAL);

            clienteDAL.InsertChanges();

            produtoDAL.Dispose();
            pedidoDAL.Dispose();
            clienteDAL.Dispose();
        }

        private static void InsertProdutos(ProdutoDAL produtoDAL)
        {
            produtos = new List<Produto>
                {
                    new Produto { Nome="Produto A",Peso = 100,Quantidade = 1,preco = 50.25M},
                    new Produto { Nome="Produto B",Peso = 200,Quantidade = 1,preco = 65.25M},
                    new Produto { Nome="Produto C",Peso = 300,Quantidade = 4,preco = 125.25M }
                };
            produtos.ForEach(produtoDAL.Insert); ;
        }

        private static void InsertPedidos(PedidoDAL pedidoDAL)
        {
            pedidos = new List<Pedido>
                {
                    new Pedido { DataPedido = DateTime.Now,Vendedor = "Vendedor A",Situacao = false,Observacao = "Obsevação A",Produtos = produtos }
                };
            pedidos.ForEach(pedidoDAL.Insert);
        }

        private static Pedido GetPedido()
        {
            using (var pedidoDAL = new PedidoDAL())
            {
                Pedido pedido = pedidoDAL.Get(p => p.Vendedor.Equals("Vendedor A")).First<Pedido>();
                return pedido;
            }
        }

        private static void InsertCliente(ClienteDAL clienteDAL)
        {
            new List<Cliente>
                {
                    new Cliente {Nome="Cliente A",DatNasc = DateTime.Now,LimiteCredito  = 1000,CartaoCredito = 102030,Contato="email@email.com",Situacao = false,Pedidos = pedidos}
                }.ForEach(clienteDAL.Insert);
        }
    }
}
