using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hr.DB.Configuration;

internal class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
	public void Configure(EntityTypeBuilder<Candidate> builder)
	{
		builder.HasMany(x => x.PlacesOfWork).WithOne(x => x.Candidate).OnDelete(DeleteBehavior.Cascade);
		builder.HasMany(x => x.CandidateStatuses).WithOne(x => x.Candidate).OnDelete(DeleteBehavior.Cascade);

		builder.HasData(
			new Candidate
			{
				Id = 1,
				FullName = "Ivan Petrov",
				DateOfBirth = new DateTime(1990, 3, 12),
				Education = Enums.Education.HigherTechnical,
				University = "GUAP",
				Faculty = "INDO"
			},
			new Candidate
			{
				Id = 2,
				FullName = "Semen Ivanov",
				DateOfBirth = new DateTime(1995, 7, 16),
				Education = Enums.Education.IncompleteHigherEducation,
				University = "GUAP",
				Faculty = "IITP"
			},
			new Candidate
			{
				Id = 3,
				FullName = "Igor Sidorov",
				DateOfBirth = new DateTime(1985, 12, 7),
				Education = Enums.Education.SecondarySpecialized,
				University = "SPPK",
				Faculty = "Programming in computer systems"
			}
		);
	}
}
