using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entidade;

namespace WebApp.Infrastructure.Mappings
{
    public class MapeadorBanco : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("Banco");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Nome).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Codigo).IsRequired().HasMaxLength(10);
            builder.Property(b => b.PercentualJuros).IsRequired();
        }
    }
}
