using Produtos.Models;

namespace Produtos.Interfaces
{
    public interface IProduto
    {
        Task Cadastrar(Produto produto);

        Task<List<Produto>> ListarTodos();

        Task<Produto?> BuscarPorId(int id);

        Task Atualizar(int id, Produto produto);

        Task Deletar(int id);
    }
}