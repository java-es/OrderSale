using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("produto")]
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        public int Peso { get; set; }
        public int Quantidade { get; set; }
        public decimal preco { get; set; }
        public Pedido Pedido { get; set; }
    }
}
