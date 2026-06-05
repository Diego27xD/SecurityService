using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Models;
using System.Diagnostics;

namespace SecurityServiceBackend.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var listaIngresos = new List<IngresoModel>()
			{
				new IngresoModel
				{
					PersonalIngresante = "Diego Flores",
					DniIngresante = "87878878",
					PlacaVehiculo = "DSC123",
					FechaIngreso = "02/03/2026",
					PersonalEncargado = "Antonio Cotito"
				},

				new IngresoModel
				{
					PersonalIngresante = "Carlos Ramirez",
					DniIngresante = "74125896",
					PlacaVehiculo = "ABC456",
					FechaIngreso = "05/03/2026",
					PersonalEncargado = "Luis Perez"
				},

				new IngresoModel
				{
					PersonalIngresante = "María Torres",
					DniIngresante = "96385274",
					PlacaVehiculo = "XYZ999",
					FechaIngreso = "10/03/2026",
					PersonalEncargado = "Andrea Rojas"
				}
			};

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
