using Dominio.Entidade;

namespace Dominio.Interface
{
    public interface IRepositorioUsuario
    {
        Task<Usuario?> ObterPorIdAsync(int id);
        Task<Usuario?> ObterPorLoginAsync(string login);
        Task<List<Usuario>> ObterTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(Usuario usuario);
        Task<bool> SalvarAsync();
    }
}
