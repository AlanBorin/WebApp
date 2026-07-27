using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidade;

namespace Infraestrutura.Repositories
{
    public class RepositorioUsuario : Dominio.Interface.IRepositorioUsuario
    {
        private readonly AppDbContext _context;

        public RepositorioUsuario(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObterPorIdAsync(int id)
            => await _context.Usuarios.FindAsync(id);

        public async Task<Usuario?> ObterPorLoginAsync(string login)
            => await _context.Usuarios.FirstOrDefaultAsync(u => u.Login == login);

        public async Task<List<Usuario>> ObterTodosAsync()
            => await _context.Usuarios.ToListAsync();

        public async Task AdicionarAsync(Usuario usuario)
            => await _context.Usuarios.AddAsync(usuario);

        public void Atualizar(Usuario usuario)
            => _context.Usuarios.Update(usuario);

        public void Remover(Usuario usuario)
            => _context.Usuarios.Remove(usuario);

        public async Task<bool> SalvarAsync()
            => await _context.SaveChangesAsync() > 0;
    }
}
