using Dominio.Entidade;

namespace Dominio.Interface
{
    public interface IRepositorioBanco
    {
        Task<Banco?> ObterPorIdAsync(int id);
        Task<Banco?> ObterPorCodigoAsync(string codigo);
        Task<List<Banco>> ObterTodosAsync();
        Task AdicionarAsync(Banco banco);
        void Atualizar(Banco banco);
        void Remover(Banco banco);
        Task<bool> SalvarAsync();
    }
}
