using hr.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace hr.Tests
{
	internal static class ContextFactory
	{
		public static ApplicationDbContext Create()
		{
			var connection = new SqliteConnection("Filename=:memory:");
			connection.Open();

			var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseSqlite(connection)
				.Options;

			var context = new ApplicationDbContext(contextOptions);

			return context;
		}
	}
}
