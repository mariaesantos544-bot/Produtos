
using Produtos.BdContextProdutos;
using Produtos.Interfaces;
using Produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace Produtos.Repositories
{
    public class ProdutoRepository : IProduto
    {
        private readonly ProdutoContext _context;

        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }

        public async Task Cadastrar(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> ListarTodos()
        {
            return await _context.Produtos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Produto?> BuscarPorId(int id)
        {
            return await _context.Produtos
                .FirstOrDefaultAsync(p => p.IdProduto == id);
        }

        public async Task Atualizar(int id, Produto produto)
        {
            var ProdutoBuscado = await _context.Produtos.FindAsync(id);

            if (ProdutoBuscado != null)
            {
                ProdutoBuscado.Nome = produto.Nome;
                ProdutoBuscado.Marca = produto.Marca;
                ProdutoBuscado.Preco = produto.Preco;
                ProdutoBuscado.QuantidadeEstoque = produto.QuantidadeEstoque;
                ProdutoBuscado.Ativo = produto.Ativo;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Deletar(int id)
        {
            var ProdutoBuscado = await _context.Produtos.FindAsync(id);

            if (ProdutoBuscado != null)
            {
                _context.Produtos.Remove(ProdutoBuscado);
                await _context.SaveChangesAsync();
            }
        }
    }
}