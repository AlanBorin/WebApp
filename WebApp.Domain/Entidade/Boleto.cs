namespace WebApp.Domain.Entidade
{
    public class Boleto
    {
        public int Id { get; set; }
        public string NomePagador { get; set; } = string.Empty;
        public string CPFCNPJPagador { get; set; } = string.Empty;
        public string NomeBeneficiario { get; set; } = string.Empty;
        public string CPFCNPJBeneficiario { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string observacao { get; set; } = string.Empty;
        public int BancoId { get; set; }

    }
}
