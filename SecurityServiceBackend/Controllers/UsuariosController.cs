using Microsoft.AspNetCore.Mvc;
using SecurityServiceBackend.Data;
using SecurityServiceBackend.Models;
using Microsoft.EntityFrameworkCore;

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
			var listaUsuarios = (
				from p in _context.PersPersons
				join d in _context.AuthDepartments
					on p.AuthDeptId equals d.Id into departamentos
				from d in departamentos.DefaultIfEmpty()

				select new UsuarioModel
				{
					NombreCompleto = (p.Name ?? "") + " " + (p.LastName ?? ""),
					Documento = p.Pin,
					Telefono = p.MobilePhone,
					FechaIngreso = "",
					Departamento = d != null ? d.Name : "",
					Estado = p.Status == 0 ? "Activo" : "Inactivo"
				}
			)
			.Take(100)
			.ToList();

			return View(listaUsuarios);
		}
	}
}
