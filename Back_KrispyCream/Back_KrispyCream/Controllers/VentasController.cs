using Back_KrispyCream.Data;
using Back_KrispyCream.Models.Dtos;
using Back_KrispyCream.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_KrispyCream.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VentasController : ControllerBase
    {
        private readonly TiendaContext _context;

        public VentasController(TiendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var ventas = await _context.Ventas.ToListAsync();
            return Ok(ventas);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVenta([FromBody] VentaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venta = new Venta
            {
                Producto = dto.Producto,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,
                TotalGanacia = dto.Cantidad * dto.Precio,
                CreadoPor = User.Identity.Name,
                CreadoEn = DateTime.Now,
                ActualizadoPor = string.Empty,
                ActualizadoEn = DateTime.Now
            };

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return Ok("Venta registrada");
        }

    }
}
