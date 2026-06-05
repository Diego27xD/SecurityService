using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityServiceBackend.Models
{
	[Table("pers_person")]
	public class PersPerson
	{
		[Key]
		[Column("id")]
		public string Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("last_name")]
		public string LastName { get; set; }

		[Column("pin")]
		public string Pin { get; set; }

		[Column("mobile_phone")]
		public string MobilePhone { get; set; }

		[Column("status")]
		public int? Status { get; set; }

		[Column("auth_dept_id")]
		public string AuthDeptId { get; set; }

		[Column("position_id")]
		public string PositionId { get; set; }
	}
}
