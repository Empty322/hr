using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace hr.DB.Configuration;

internal class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
{
	public void Configure(EntityTypeBuilder<Vacancy> builder)
	{
		builder.HasData(
			new Vacancy
			{
				Id = 1,
				Title = "Developer",
				Description = "A software developer is a person or company engaged in software development process, " +
				"including research, design, programming, testing, and other facets of creating computer software. " +
				"Other job titles for individuals with similar meanings include programmer, software analyst, or software engineer. " +
				"Companies specializing in software may be called software houses. In a large company, there may be employees whose " +
				"sole responsibility consists of only one of the disciplines. In smaller development environments, a few people or " +
				"even a single individual might handle the complete process. Collaborative environments, such as open-source software, can bring together many developers."
			},
			new Vacancy
			{
				Id = 2,
				Title = "System administrator",
				Description = "A system administrator, or sysadmin, or admin is a person who is responsible for the upkeep, " +
				"configuration, and reliable operation of computer systems, especially multi-user computers, such as servers. " +
				"The system administrator seeks to ensure that the uptime, performance, resources, and security of the " +
				"computers they manage meet the needs of the users, without exceeding a set budget when doing so."
			},
			new Vacancy
			{
				Id = 3,
				Title = "Business analyst",
				Description = "A business analyst (BA) is a person who processes, interprets and documents business processes, " +
				"products, services and software through analysis of data. The role of a business analyst is to ensure business " +
				"efficiency increases through their knowledge of both IT and business function."
			}
		);
	}
}
