using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Models;

namespace SecurityServiceBackend.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View("Main");
        }

        public IActionResult Register()
        {
            List<Example> listExamples = new List<Example>();

            listExamples.Add(new Example { Nombre = "John", Apellido = "Doe" });
            listExamples.Add(new Example { Nombre = "Jane", Apellido = "Smith" });

            ViewBag.Title = "Pagina para registrar";

            return View("Register", listExamples);
        }

        public IActionResult Login()
        {
            return View("Login");
        }
    }
}
