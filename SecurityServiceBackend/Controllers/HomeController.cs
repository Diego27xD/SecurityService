using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Data;
using SecurityServiceBackend.Models;
using System.Diagnostics;

namespace SecurityServiceBackend.Controllers
{
	public class HomeController : Controller
	{

		private readonly IngresoRepository _repo;


		public HomeController(IngresoRepository repository)
		{
			_repo = repository;
		}


		public IActionResult Index()
		{
			var listaIngresos = _repo.ObtenerIngresos();

			return View(listaIngresos);
		}


		public IActionResult Privacy()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel
			{
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			});
		}

	}
}
