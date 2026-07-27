using Dominio.Entidade;

namespace Dominio.Interface
{
    public interface IRepositorioBoleto
    {
        Task<Boleto?> ObterPorIdAsync(int id);
        Task<List<Boleto>> ObterTodosAsync();
        Task<List<Boleto>> ObterPorBancoIdAsync(int bancoId);
        Task AdicionarAsync(Boleto boleto);
        void Atualizar(Boleto boleto);
        void Remover(Boleto boleto);
        Task<bool> SalvarAsync();
    }
}
