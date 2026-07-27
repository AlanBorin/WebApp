namespace Dominio.Entidade
{
    public class Banco
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public decimal PercentualJuros { get; set; }

    }
}