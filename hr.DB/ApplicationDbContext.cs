using hr.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace hr.DB
{
	public class ApplicationDbContext: DbContext
	{
		public DbSet<Candidate> Candidates { get; set; } = null!;
		public DbSet<Vacancy> Vacancies { get; set; } = null!;
		public DbSet<PlaceOfWork> PlacesOfWork { get; set; } = null!;
		public DbSet<CandidateStatus> CandidateStatuses { get; set; } = null!;
		public DbSet<Technology> Technologies { get; set; } = null!;

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
		}
	}
}