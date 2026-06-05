using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityServiceBackend.Models
{
	[Table("auth_department")]
	public class AuthDepartment
	{
		[Key]
		[Column("id")]
		public string Id { get; set; }

		[Column("name")]
		public string Name { get; set; }
	}
}
