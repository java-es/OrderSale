using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("cliente")]
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public DateTime DatNasc { get; set; }
        public decimal LimiteCredito { get; set; }
        public int CartaoCredito { get; set; }
        public string Contato { get; set; }
        public bool Situacao { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
