using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecurityServiceBackend.Data;
using SecurityServiceBackend.ViewModel;


namespace SecurityServiceBackend.Controllers
{

	public class AccesoController : Controller
	{

		private readonly ApplicationDbContext _context;


		public AccesoController(ApplicationDbContext context)
		{
			_context = context;
		}



		public IActionResult Index()
		{

			var usuarios = _context.Usuarios
				.Select(u => new UsuarioAccesoViewModel
				{

					Id = u.Id,

					NombreUsuario = u.NombreUsuario,

					Nombre = u.Nombre,

					EstadoPassword =
						u.RequiereCambioPassword
						? "Pendiente"
						: "Actualizada",


					FechaCreacion = u.FechaCreacion


				})
				.ToList();



			return View(usuarios);

		}

	}

}
