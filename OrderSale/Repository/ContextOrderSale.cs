using Model;
using System.Data.Entity;

namespace Repository
{
    public class ContextOrderSale : DbContext
    {
        public ContextOrderSale() : base("ConnDB") { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
