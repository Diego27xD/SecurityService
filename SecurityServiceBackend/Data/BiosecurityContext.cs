using Microsoft.EntityFrameworkCore;
using SecurityServiceBackend.Models;

namespace SecurityServiceBackend.Data
{
	public class BiosecurityContext : DbContext
	{
		public BiosecurityContext(DbContextOptions<BiosecurityContext> options)
			: base(options)
		{
		}

		public DbSet<PersPerson> PersPersons { get; set; }

		public DbSet<AuthDepartment> AuthDepartments { get; set; }
	}
}
