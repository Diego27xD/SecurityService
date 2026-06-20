namespace SecurityServiceBackend.Models
{
	public class IngresoModel
	{
		public string Matricula { get; set; }

		public string PropietarioOficial { get; set; }

		public string DNI { get; set; }

		public DateTime HoraIngreso { get; set; }

		public DateTime? HoraSalida { get; set; }

		public string UsuarioManejando { get; set; }

		public string AreaDestino { get; set; }
	}
}