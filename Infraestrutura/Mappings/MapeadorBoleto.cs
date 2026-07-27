using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entidade;

namespace WebApp.Infrastructure.Mappings
{
    public class MapeadorBoleto : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.ToTable("Boleto");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.NomePagador).IsRequired().HasMaxLength(100);
            builder.Property(b => b.CPFCNPJPagador).IsRequired().HasMaxLength(20);
            builder.Property(b => b.NomeBeneficiario).IsRequired().HasMaxLength(100);
            builder.Property(b => b.CPFCNPJBeneficiario).IsRequired().HasMaxLength(20);
            builder.Property(b => b.Valor).IsRequired();
            builder.Property(b => b.DataVencimento).IsRequired();
            builder.Property(b => b.Observacao).IsRequired(false).HasMaxLength(500);
            builder.Property(b => b.BancoId).IsRequired();

            builder.HasOne<Banco>()
                .WithMany()
                .HasForeignKey(b => b.BancoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}