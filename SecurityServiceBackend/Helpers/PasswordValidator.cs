using System.Text.RegularExpressions;

namespace SecurityServiceBackend.Helpers
{
	public static class PasswordValidator
	{

		public static bool EsValida(string password)
		{

			if (string.IsNullOrEmpty(password))
				return false;


			// mínimo 6 caracteres
			// al menos una letra
			// al menos un número
			// al menos un carácter especial

			return Regex.IsMatch(
				password,
				@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$"
			);

		}


	}
}