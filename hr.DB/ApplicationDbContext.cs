using hr.DB.Models;
using Microsoft.EntityFrameworkCore;

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

			modelBuilder.Entity<Candidate>().HasMany(x => x.PlacesOfWork).WithOne(x => x.Candidate).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Candidate>().HasMany(x => x.CandidateStatuses).WithOne(x => x.Candidate).OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<TechnologyPlaceOfWork>().HasOne(x => x.PlaceOfWork).WithMany(x => x.Technologies);
			modelBuilder.Entity<TechnologyPlaceOfWork>().HasKey(x => new { x.PlaceOfWorkId, x.TechnologyTitle });

			modelBuilder.Entity<TechnologyVacancy>().HasOne(x => x.Vacancy).WithMany(x => x.Technologies);
			modelBuilder.Entity<TechnologyVacancy>().HasKey(x => new { x.VacancyId, x.TechnologyTitle });
		}
	}
}