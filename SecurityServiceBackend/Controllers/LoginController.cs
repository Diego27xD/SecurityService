using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Models;
using SecurityServiceBackend.Services;

namespace SecurityServiceBackend.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IJwtService _jwtService;

        public LoginController(IUsuarioService usuarioService, IJwtService jwtService)
        {
            _usuarioService = usuarioService;
            _jwtService = jwtService;
        }
        // Mostrar formulario
        [AllowAnonymous]
        [HttpGet]
		public IActionResult Login()
		{
			return View();
		}

        // Procesar login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = await _usuarioService.ValidarCredencialesAsync(model.Usuario, model.Password);

            if (usuario == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View(model);
            }

            var token = _jwtService.GenerarToken(usuario);
            HttpContext.Session.SetString("JWToken", token);

            if (usuario.RequiereCambioPassword)
            {
                return RedirectToAction(nameof(CambiarPasswordController.CambiarPassword), "CambiarPassword");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
