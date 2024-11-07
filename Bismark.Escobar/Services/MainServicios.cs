using Bismark.Escobar.Interfaces;
using Bismark.Escobar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using static Bismark.Escobar.Services.MainServicios;

namespace Bismark.Escobar.Services
{
    public class MainServicios: MisInterfaces
    {
        private readonly DbContext _dbContext;

        public List<Cliente> DatosCliente(DbContext_ dbContext_, int Id)
        {
            List<Cliente> cliente = new List<Cliente>();
            Cliente data;
            try
            {
                List<Cliente> cls = dbContext_.clientes
                              .Where(u => u.Id == Id)
                              .ToList();

                foreach (var item in cls)
                {
                    data = new Cliente();
                    data.Id = item.Id;
                    data.Nombre = item.Nombre;
                    data.FechaNacimiento = item.FechaNacimiento;
                    data.Sexo = item.Sexo;
                    data.Ingresos = item.Ingresos;
                    cliente.Add(data);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cliente;
        }

        public void CrearCliente(DbContext_ dbContext_, Cliente cliente)
        {
            try
            {
                dbContext_.clientes.Add(cliente);
                dbContext_.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CrearCuenta(DbContext_ dbContext_, Cuenta cuenta)
        {
            try
            {
                dbContext_.cuenta.Add(cuenta);
                dbContext_.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GenerarTransaccion(DbContext_ dbContext_, Transacciones transacciones)
        {
            try
            {
                if(transacciones.Tipo == TipoTransacciones.retiro)
                {
                    var listaFiltrada = dbContext_.cuenta.Where(obj => obj.SaldoInicial >= transacciones.Monto).ToList();
                    if (listaFiltrada.Count() > 0)
                    {
                        var cuentaExistente = dbContext_.cuenta.FirstOrDefault(c => c.Id == transacciones.CuentaId);
                        cuentaExistente.SaldoInicial = cuentaExistente.SaldoInicial - transacciones.Monto;
                        dbContext_.cuenta.Update(cuentaExistente);

                        dbContext_.Transacciones.Add(transacciones);
                        dbContext_.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("No se encontraron cuentas con saldo suficiente."); ;
                    }
                    
                }else
                {
                    var cuentaExistente = dbContext_.cuenta.FirstOrDefault(c => c.Id == transacciones.CuentaId);
                    cuentaExistente.SaldoInicial = cuentaExistente.SaldoInicial + transacciones.Monto;
                    dbContext_.cuenta.Update(cuentaExistente);

                    dbContext_.Transacciones.Add(transacciones);
                    dbContext_.SaveChanges();
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Saldos> Saldos(DbContext_ dbContext_, int Id)
        {
            List<Saldos> cuenta = new List<Saldos>();
            Saldos data;
            try
            {
                var cuentasClientes = dbContext_.cuenta
                  .Join(dbContext_.clientes,
                        cuenta => cuenta.ClienteId, 
                        cliente => cliente.Id,
                        (cuenta, cliente) => new { cuenta, cliente })
         
                  .ToList();

                foreach (var item in cuentasClientes)
                {
                    data = new Saldos();
                    data.NumeroCuenta = item.cuenta.NumeroCuenta;
                    data.Cliente = item.cliente.Nombre;
                    data.SaldoInicial = item.cuenta.SaldoInicial;
                    data.Tipo = Enum.GetName(typeof(TipoCuenta), item.cuenta.Tipo);
                    cuenta.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return cuenta;
        }

        public List<Historico> HistoricoCuenta(DbContext_ dbContext_, int Id)
        {
            List<Historico> historicos = new List<Historico>();
            Historico data;
            try
            {
                var cuentasClientes = dbContext_.Transacciones
                  .Join(dbContext_.cuenta,
                        transaccion => transaccion.CuentaId,
                        cuenta => cuenta.Id,
                        (Transacciones, cuenta) => new { Transacciones, cuenta })
                  .Join(dbContext_.clientes,
                        cuenta => cuenta.cuenta.ClienteId,
                        cliente => cliente.Id,
                        (cuenta, Cliente) => new { cuenta, Cliente })
                  .OrderBy(c => c.cuenta.Transacciones.FechaTransaccion)
                  .ToList();

                foreach (var item in cuentasClientes)
                {
                    data = new Historico();
                    data.NumeroCuenta = item.cuenta.cuenta.NumeroCuenta;
                    data.Cliente = item.Cliente.Nombre;
                    data.monto = item.cuenta.Transacciones.Monto;
                    data.saldo = item.cuenta.cuenta.SaldoInicial;
                    data.Tipo = Enum.GetName(typeof(TipoTransacciones), item.cuenta.Transacciones.Tipo);
                    historicos.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return historicos;
        }
    }
}
