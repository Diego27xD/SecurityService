using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Models;

namespace SecurityServiceBackend.Controllers
{
    public class LoginController : Controller
    {
		// Mostrar formulario
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		// Procesar login
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			// Validar campos
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			if (model.Usuario == "rodolfo" &&
				model.Password == "123456")
			{
				return RedirectToAction("Index", "Home");
			}

			ViewBag.Error = "usuario o contraseña incorrectos";

			return View(model);
		}
	}
}
