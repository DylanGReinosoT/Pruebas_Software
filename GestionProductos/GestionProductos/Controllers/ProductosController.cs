using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionProductos.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController : Controller
	{
		private readonly AppDBContext _dbContext;
		public string password;

		public ProductosController(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			return Ok(await _dbContext.Productos.ToListAsync());
		}

		[HttpPost]
		public async Task<IActionResult> PostProductos(Producto producto)
		{
			if (producto.Precio < 0) return BadRequest("El precio no puede ser negativo");
			_dbContext.Productos.Add(producto);
			await _dbContext.SaveChangesAsync();
			return Ok(producto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProducto(int id, Producto producto)
		{
			if (id != producto.Id)
			{
				return BadRequest("El Id del producto no coincide con el Id de la URL.");
			}

			var productoExistente = await _dbContext.Productos.FindAsync(id);
			if (productoExistente == null)
			{
				return NotFound($"No se encontró un producto con Id {id}");
			}

			if (producto.Precio < 0)
			{
				return BadRequest("El precio no puede ser negativo.");
			}

			// Actualizar campos del producto existente
			productoExistente.Nombre = producto.Nombre;
			productoExistente.Descripcion = producto.Descripcion;
			productoExistente.Precio = producto.Precio;
			productoExistente.Stock = producto.Stock;

			await _dbContext.SaveChangesAsync();
			return Ok(productoExistente);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProducto(int id)
		{
			var producto = await _dbContext.Productos.FindAsync(id);
			if (producto == null)
			{
				return NotFound($"No se encontró un producto con Id {id}");
			}

			_dbContext.Productos.Remove(producto);
			await _dbContext.SaveChangesAsync();

			return Ok($"Producto con Id {id} eliminado correctamente.");
		}



		//public IActionResult Index()
		//{
		//	return View();
		//}
	}
}
