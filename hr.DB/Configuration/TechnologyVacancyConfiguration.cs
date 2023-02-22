using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hr.DB.Configuration;

internal class TechnologyVacancyConfiguration : IEntityTypeConfiguration<TechnologyVacancy>
{
	public void Configure(EntityTypeBuilder<TechnologyVacancy> builder)
	{
		builder.HasOne(x => x.Vacancy).WithMany(x => x.Technologies);
		builder.HasKey(x => new { x.VacancyId, x.TechnologyTitle });

		builder.HasData(
			new TechnologyVacancy
			{
				VacancyId = 1,
				TechnologyTitle = "c++"
			},
			new TechnologyVacancy
			{
				VacancyId = 1,
				TechnologyTitle = "sql"
			},
			new TechnologyVacancy
			{
				VacancyId = 1,
				TechnologyTitle = "js"
			},
			new TechnologyVacancy
			{
				VacancyId = 2,
				TechnologyTitle = "sql"
			},
			new TechnologyVacancy
			{
				VacancyId = 3,
				TechnologyTitle = "jira"
			}
		);
	}
}
