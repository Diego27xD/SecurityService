using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Services;
using SecurityServiceBackend.ViewModel;

namespace SecurityServiceBackend.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public RegistroController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View(new RegistroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _usuarioService.ExisteUsuarioAsync(model.Usuario))
            {
                ViewBag.Error = "Ese usuario ya existe";
                return View(model);
            }

            await _usuarioService.RegistrarUsuarioAsync(model.Usuario, model.Nombre);

            ViewBag.Mensaje = "Usuario registrado correctamente. Se le asignó una contraseña genérica " +
                               "y deberá cambiarla en su primer ingreso.";

            return View(new RegistroViewModel());
        }
    }
}
