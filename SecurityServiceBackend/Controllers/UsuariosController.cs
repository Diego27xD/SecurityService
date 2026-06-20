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



		public IActionResult Index(
			int page = 1,
			int limit = 10,
			string buscar = ""
		)
		{


			var consulta =
				from p in _context.PersPersons


				join d in _context.AuthDepartments
				on p.AuthDeptId equals d.Id into departamentos

				from d in departamentos.DefaultIfEmpty()



				join c in _context.PersPositions
				on p.PositionId equals c.Id into cargos

				from c in cargos.DefaultIfEmpty()



				select new UsuarioModel
				{

					NombreCompleto =
						p.Name + " " + p.LastName,


					Documento =
						p.Pin,


					Telefono =
						p.MobilePhone,


					Cargo =
						c != null ? c.Name : "",


					Departamento =
						d != null ? d.Name : "",


					Estado =
						p.Status == 0 ? "Activo" : "Inactivo"

				};





			// BUSQUEDA EN BASE DE DATOS

			if (!string.IsNullOrWhiteSpace(buscar))
			{
				consulta = consulta.Where(x =>
					EF.Functions.ILike(x.NombreCompleto, $"%{buscar}%") ||
					EF.Functions.ILike(x.Documento, $"%{buscar}%") ||
					EF.Functions.ILike(x.Telefono, $"%{buscar}%") ||
					EF.Functions.ILike(x.Cargo, $"%{buscar}%") ||
					EF.Functions.ILike(x.Departamento, $"%{buscar}%") ||
					EF.Functions.ILike(x.Estado, $"%{buscar}%")
				);
			}




			// TOTAL PARA PAGINACION

			int totalRegistros = consulta.Count();






			// SOLO TRAE LOS REGISTROS NECESARIOS

			var usuarios = consulta

				.Skip((page - 1) * limit)

				.Take(limit)

				.ToList();






			// SI VIENE DE AJAX SOLO DEVUELVE FILAS

			if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
			{

				var modeloAjax = new UsuarioPaginadoModel
				{
					Usuarios = usuarios,

					PaginaActual = page,

					TotalRegistros = totalRegistros,

					TotalPaginas =
					(int)Math.Ceiling(
						totalRegistros / (double)limit
					),

					Busqueda = buscar
				};


				return PartialView(
					"_UsuariosPartial",
					modeloAjax
				);

			}






			// MODELO COMPLETO PARA LA VISTA

			var modelo = new UsuarioPaginadoModel
			{
				Usuarios = usuarios,

				PaginaActual = page,

				TotalRegistros = totalRegistros,

				TotalPaginas =
		(int)Math.Ceiling(
			totalRegistros / (double)limit
		),

				Busqueda = buscar
			};




			return View(modelo);

		}


	}

}