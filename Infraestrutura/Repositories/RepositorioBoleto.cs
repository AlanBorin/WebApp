using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidade;

namespace Infraestrutura.Repositories
{
    public class RepositorioBoleto : Dominio.Interface.IRepositorioBoleto
    {
        private readonly AppDbContext _context;

        public RepositorioBoleto(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Boleto?> ObterPorIdAsync(int id)
            => await _context.Boletos.FindAsync(id);

        public async Task<List<Boleto>> ObterTodosAsync()
            => await _context.Boletos.ToListAsync();

        public async Task<List<Boleto>> ObterPorBancoIdAsync(int bancoId)
            => await _context.Boletos.Where(b => b.BancoId == bancoId).ToListAsync();

        public async Task AdicionarAsync(Boleto boleto)
            => await _context.Boletos.AddAsync(boleto);

        public void Atualizar(Boleto boleto)
            => _context.Boletos.Update(boleto);

        public void Remover(Boleto boleto)
            => _context.Boletos.Remove(boleto);

        public async Task<bool> SalvarAsync()
            => await _context.SaveChangesAsync() > 0;
    }
}
