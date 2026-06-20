using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Services;
using SecurityServiceBackend.ViewModel;
using System.Security.Claims;

namespace SecurityServiceBackend.Controllers
{
    public class CambiarPasswordController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IJwtService _jwtService;

        public CambiarPasswordController(IUsuarioService usuarioService, IJwtService jwtService)
        {
            _usuarioService = usuarioService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult CambiarPassword()
        {
            return View(new CambiarPasswordViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CambiarPassword(CambiarPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var ok = await _usuarioService.CambiarPasswordAsync(usuarioId, model.PasswordActual, model.PasswordNueva);

            if (!ok)
            {
                ViewBag.Error = "La contraseña actual no es correcta";
                return View(model);
            }

            // Se regenera el token sin la marca "mustChangePassword" para no
            // quedar atrapado en este formulario en el siguiente request.
            var usuario = await _usuarioService.ObtenerPorIdAsync(usuarioId);
            var nuevoToken = _jwtService.GenerarToken(usuario!);
            HttpContext.Session.SetString("JWToken", nuevoToken);

            return RedirectToAction("Index", "Home");
        }
    }
}
