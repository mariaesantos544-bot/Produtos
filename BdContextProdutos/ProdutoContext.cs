using Microsoft.EntityFrameworkCore;
using Produtos.Models;

namespace Produtos.BdContextProdutos
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}