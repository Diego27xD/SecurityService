using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Services;
using SecurityServiceBackend.ViewModel;
using SecurityServiceBackend.Helpers;
using System.Security.Claims;

namespace SecurityServiceBackend.Controllers
{
	public class CambiarPasswordController : Controller
	{

		private readonly IUsuarioService _usuarioService;
		private readonly IJwtService _jwtService;



		public CambiarPasswordController(
			IUsuarioService usuarioService,
			IJwtService jwtService)
		{

			_usuarioService = usuarioService;
			_jwtService = jwtService;

		}





		[HttpGet]
		public IActionResult CambiarPassword()
		{

			return View(
				new CambiarPasswordViewModel()
			);

		}





		[HttpPost]
		public async Task<IActionResult> CambiarPassword(
			CambiarPasswordViewModel model)
		{


			if (!ModelState.IsValid)
			{

				return View(model);

			}




			// Validar nueva contraseña

			if (!PasswordValidator.EsValida(model.PasswordNueva))
			{

				ViewBag.Error =
					"La nueva contraseña debe tener mínimo 6 caracteres, letras, números y un carácter especial.";


				return View(model);

			}





			var usuarioId =
				int.Parse(
					User.FindFirstValue(
						ClaimTypes.NameIdentifier
					)!
				);






			var ok =
				await _usuarioService.CambiarPasswordAsync(
					usuarioId,
					model.PasswordActual,
					model.PasswordNueva
				);





			if (!ok)
			{

				ViewBag.Error =
					"La contraseña actual no es correcta";


				return View(model);

			}






			// Actualizar token después del cambio

			var usuario =
				await _usuarioService.ObtenerPorIdAsync(
					usuarioId
				);



			var nuevoToken =
				_jwtService.GenerarToken(
					usuario!
				);



			HttpContext.Session.SetString(
				"JWToken",
				nuevoToken
			);





			return RedirectToAction(
				"Index",
				"Home"
			);


		}


	}
}