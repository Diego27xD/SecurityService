using System.ComponentModel.DataAnnotations.Schema;

namespace SecurityServiceBackend.Models
{
	[Table("pers_position")]
	public class PersPosition
	{
		[Column("id")]
		public string Id { get; set; }


		[Column("name")]
		public string Name { get; set; }
	}
}