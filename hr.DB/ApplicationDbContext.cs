using hr.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace hr.DB
{
	public class ApplicationDbContext: DbContext
	{
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Vacancy> Vacancies { get; set; }
		public DbSet<PlaceOfWork> PlacesOfWork { get; set; }
		public DbSet<CandidateStatus> CandidateStatuses { get; set; }
		public DbSet<Technology> Technologies { get; set; }

		public ApplicationDbContext() : base()
		{

		}
	}
}