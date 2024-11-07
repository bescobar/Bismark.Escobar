namespace Bismark.Escobar.Models
{
    public class Transacciones
    {
        public int Id { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public TipoTransacciones Tipo { get; set; }
        public decimal Monto { get; set; }
        public int CuentaId { get; set; }
    }
}
