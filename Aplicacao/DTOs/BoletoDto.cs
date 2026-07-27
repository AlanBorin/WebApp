using System.ComponentModel.DataAnnotations;

namespace Aplicacao.DTOs
{
    public class BoletoDto
    {
        public int Id { get; set; }
        public string NomePagador { get; set; } = string.Empty;
        public string CPFCNPJPagador { get; set; } = string.Empty;
        public string NomeBeneficiario { get; set; } = string.Empty;
        public string CPFCNPJBeneficiario { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacao { get; set; } = string.Empty;
        public int BancoId { get; set; }
        public decimal ValorComJuros { get; set; }
        public bool Vencido { get; set; }
    }

    public class BoletoCriacaoDto
    {
        [Required(ErrorMessage = "O nome do pagador é obrigatório.")]
        public string NomePagador { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF/CNPJ do pagador é obrigatório.")]
        public string CPFCNPJPagador { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome do beneficiário é obrigatório.")]
        public string NomeBeneficiario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF/CNPJ do beneficiário é obrigatório.")]
        public string CPFCNPJBeneficiario { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatória.")]
        public DateTime DataVencimento { get; set; }

        public string Observacao { get; set; } = string.Empty; // não obrigatório

        [Required(ErrorMessage = "O BancoId é obrigatório.")]
        public int BancoId { get; set; }
    }
}