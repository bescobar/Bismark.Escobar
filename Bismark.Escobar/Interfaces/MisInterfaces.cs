using Bismark.Escobar.Models;

namespace Bismark.Escobar.Interfaces
{
    public interface MisInterfaces
    {
        public void CrearCliente(DbContext_ dbContext, Cliente cliente);
        public List<Cliente> DatosCliente(DbContext_ dbContext_, int Id);
        public void CrearCuenta(DbContext_ dbContext, Cuenta cuenta);
        public void GenerarTransaccion(DbContext_ dbContext, Transacciones transacciones);
        public List<Saldos> Saldos(DbContext_ dbContext_, int Id);
        public List<Historico> HistoricoCuenta(DbContext_ dbContext_, int Id);

    }
}
