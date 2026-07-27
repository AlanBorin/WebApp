using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidade;

namespace Infraestrutura.Repositories
{
    public class RepositorioBanco : Dominio.Interface.IRepositorioBanco
    {
        private readonly AppDbContext _context;

        public RepositorioBanco(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Banco?> ObterPorIdAsync(int id)
            => await _context.Bancos.FindAsync(id);

        public async Task<Banco?> ObterPorCodigoAsync(string codigo)
            => await _context.Bancos.FirstOrDefaultAsync(b => b.Codigo == codigo);

        public async Task<List<Banco>> ObterTodosAsync()
            => await _context.Bancos.ToListAsync();

        public async Task AdicionarAsync(Banco banco)
            => await _context.Bancos.AddAsync(banco);

        public void Atualizar(Banco banco)
            => _context.Bancos.Update(banco);

        public void Remover(Banco banco)
            => _context.Bancos.Remove(banco);

        public async Task<bool> SalvarAsync()
            => await _context.SaveChangesAsync() > 0;
    }
}
