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



		//public IActionResult Index()
		//{
		//	return View();
		//}
	}
}
