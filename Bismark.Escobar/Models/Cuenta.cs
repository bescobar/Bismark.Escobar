using System.ComponentModel.DataAnnotations;

namespace Bismark.Escobar.Models
{
    public class Cuenta
    {
        public int Id { get; set; } = 1;
        public int NumeroCuenta { get; set; } = int.MaxValue;
        public int ClienteId { get; set; }
        public decimal SaldoInicial { get; set; } = decimal.MaxValue;
        public TipoCuenta Tipo { get; set; } = new TipoCuenta();
    }
}
