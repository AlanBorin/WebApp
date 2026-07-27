using System.ComponentModel.DataAnnotations;

namespace Aplicacao.DTOs
{
    public class BancoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public decimal PercentualJuros { get; set; }
    }

    public class BancoCriacaoDto
    {
        [Required(ErrorMessage = "O nome do banco é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O código do banco é obrigatório.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O percentual de juros é obrigatório.")]
        public decimal PercentualJuros { get; set; }
    }
}