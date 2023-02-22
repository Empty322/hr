using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hr.DB.Configuration;

internal class PlaceOfWorkConfiguration : IEntityTypeConfiguration<PlaceOfWork>
{
	public void Configure(EntityTypeBuilder<PlaceOfWork> builder)
	{
		builder.HasData(
			new PlaceOfWork
			{
				Id = 1,
				Begin = new DateTime(2010, 4, 2),
				End = new DateTime(2015, 3, 4),
				Company = "Better place",
				Description = "Better place company desctiption",
				Position = "Developer",
				CandidateId = 1
			},
			new PlaceOfWork
			{
				Id = 2,
				Begin = new DateTime(2016, 1, 4),
				End = new DateTime(2018, 8, 14),
				Company = "New company",
				Description = "New company desctiption",
				Position = "Developer",
				CandidateId = 1
			},
			new PlaceOfWork
			{
				Id = 3,
				Begin = new DateTime(2008, 2, 4),
				End = new DateTime(2019, 11, 10),
				Company = "System management",
				Description = "System management company desctiption",
				Position = "System administrator",
				CandidateId = 2
			},
			new PlaceOfWork
			{
				Id = 4,
				Begin = new DateTime(2001, 2, 2),
				End = new DateTime(2004, 9, 4),
				Company = "5post",
				Description = "5post delivery company",
				Position = "Business analyst",
				CandidateId = 3
			},
			new PlaceOfWork
			{
				Id = 5,
				Begin = new DateTime(2005, 3, 4),
				End = new DateTime(2011, 5, 14),
				Company = "Ozon",
				Description = "Ozon marketplace",
				Position = "Developer",
				CandidateId = 3
			},
			new PlaceOfWork
			{
				Id = 6,
				Begin = new DateTime(2011, 3, 4),
				End = new DateTime(2021, 6, 10),
				Company = "MTS",
				Description = "MTS telecommunication company",
				Position = "Lead Developer",
				CandidateId = 3
			}
		);
	}
}
