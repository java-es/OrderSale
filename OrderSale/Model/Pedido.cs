using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("pedido")]
    public class Pedido
    {
        public int PedidoID { get; set; }
        public DateTime DataPedido { get; set; }
        public string Vendedor { get; set; }
        public bool Situacao { get; set; }
        public string Observacao { get; set; }
        public virtual List<Produto> Produtos { get; set; }
        public Cliente Cliente { get; set; }
    }
}
