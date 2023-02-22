using hr.DB.Configuration;
using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace hr.DB
{
	public class ApplicationDbContext: DbContext
	{
		public virtual DbSet<Candidate> Candidates { get; set; } = null!;
		public virtual DbSet<Vacancy> Vacancies { get; set; } = null!;
		public virtual DbSet<PlaceOfWork> PlacesOfWork { get; set; } = null!;
		public virtual DbSet<CandidateStatus> CandidateStatuses { get; set; } = null!;
		public virtual DbSet<Technology> Technologies { get; set; } = null!;

		public ApplicationDbContext() { }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new TechnologyConfiguration());
			modelBuilder.ApplyConfiguration(new CandidateConfiguration());
			modelBuilder.ApplyConfiguration(new PlaceOfWorkConfiguration());
			modelBuilder.ApplyConfiguration(new TechnologyPlaceOfWorkConfiguration());
			modelBuilder.ApplyConfiguration(new VacancyConfiguration());
			modelBuilder.ApplyConfiguration(new TechnologyVacancyConfiguration());
			modelBuilder.ApplyConfiguration(new CandidateStatusConfiguration());
		}
	}
}