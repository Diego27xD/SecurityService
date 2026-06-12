using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecurityServiceBackend.Data;
using SecurityServiceBackend.Models;

namespace SecurityServiceBackend.Controllers
{
	public class UsuariosController : Controller
	{
		private readonly BiosecurityContext _context;

		public UsuariosController(BiosecurityContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var listaUsuarios =
				(
					from p in _context.PersPersons

					join d in _context.AuthDepartments
					on p.AuthDeptId equals d.Id into departamentos
					from d in departamentos.DefaultIfEmpty()


					join c in _context.PersPositions
					on p.PositionId equals c.Id into cargos
					from c in cargos.DefaultIfEmpty()


					select new UsuarioModel
					{
						NombreCompleto = p.Name + " " + p.LastName,

						Documento = p.Pin,

						Telefono = p.MobilePhone,

						Cargo = c != null ? c.Name : "",

						Departamento = d != null ? d.Name : "",

						Estado = p.Status == 0 ? "Activo" : "Inactivo"
					}

				)
				.Take(10000)
				.ToList();


			return View(listaUsuarios);
		}
	}
}
