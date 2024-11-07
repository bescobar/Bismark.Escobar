namespace Bismark.Escobar.Models
{
    public class Saldos
    {
        public int NumeroCuenta { get; set; } = 0;
        public string Cliente { get; set; } = string.Empty;
        public decimal SaldoInicial { get; set; } = 0;
        public string Tipo { get; set; } = string.Empty;
    }
}
