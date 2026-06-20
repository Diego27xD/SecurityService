namespace SecurityServiceBackend.Models
{
	public class UsuarioPaginadoModel
	{

		public List<UsuarioModel> Usuarios { get; set; }

		public int PaginaActual { get; set; }

		public int TotalRegistros { get; set; }

		public int TotalPaginas { get; set; }


		public string Busqueda { get; set; }

	}
}
