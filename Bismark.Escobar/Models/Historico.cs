namespace Bismark.Escobar.Models
{
    public class Historico
    {
        public int NumeroCuenta { get; set; } = 0;
        public string Cliente { get; set; } = string.Empty;
        public decimal monto { get; set; } = 0;
        public decimal saldo { get; set; } = 0;
        public string Tipo { get; set; } = string.Empty;
    }
}
