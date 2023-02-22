using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace hr.DB.Configuration;

internal class TechnologyPlaceOfWorkConfiguration : IEntityTypeConfiguration<TechnologyPlaceOfWork>
{
	public void Configure(EntityTypeBuilder<TechnologyPlaceOfWork> builder)
	{
		builder.HasOne(x => x.PlaceOfWork).WithMany(x => x.Technologies);
		builder.HasKey(x => new { x.PlaceOfWorkId, x.TechnologyTitle });

		builder.HasData(
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 1,
				TechnologyTitle = "c++"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 1,
				TechnologyTitle = "sql"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 2,
				TechnologyTitle = "c++"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 3,
				TechnologyTitle = "sql"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 3,
				TechnologyTitle = "powershell"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 5,
				TechnologyTitle = "c#"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 5,
				TechnologyTitle = "js"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 6,
				TechnologyTitle = "c#"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 6,
				TechnologyTitle = "sql"
			},
			new TechnologyPlaceOfWork
			{
				PlaceOfWorkId = 6,
				TechnologyTitle = "js"
			}
		);
	}
}
