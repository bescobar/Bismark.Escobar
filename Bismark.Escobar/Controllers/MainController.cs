using Bismark.Escobar.Interfaces;
using Bismark.Escobar.Models;
using Bismark.Escobar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bismark.Escobar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly MisInterfaces _Service;
        private readonly DbContext_ _dbContext;

        public MainController(MisInterfaces misInterfaces, DbContext_ dbContext)
        {
            _Service = misInterfaces;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("CrearPerfilCliente")]
        public IActionResult CrearCliente(Cliente cliente) 
        { 
            _Service.CrearCliente(_dbContext, cliente);

            return Ok(new
            {
                isSuccess = true,
                mensaje = "Se guardó con éxito"
            });
        }

        [HttpPost]
        [Route("CrearCuenta")]
        public IActionResult CrearCuenta(Cuenta cuenta)
        {
            _Service.CrearCuenta(_dbContext, cuenta);

            return Ok();
        }

        [HttpPost]
        [Route("GenerarTransaccion")]
        public IActionResult GenerarTransaccion(Transacciones transacciones)
        {
            try
            {
                _Service.GenerarTransaccion(_dbContext, transacciones);
                return Ok("Transacción procesada correctamente.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message); 
            }
        }

        [HttpGet("getCliente/{id}")]
        public IActionResult getdataCliente(int id)
        {
            return Ok(_Service.DatosCliente(_dbContext, id));
        }

        [HttpGet("getCuenta/{id}")]
        public IActionResult Saldos(int id)
        {
            return Ok(_Service.Saldos(_dbContext, id));
        }

        [HttpGet("getHistoricoCuenta/{id}")]
        public IActionResult Historico(int id)
        {
            return Ok(_Service.HistoricoCuenta(_dbContext, id));
        }


    }
}
