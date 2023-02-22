using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hr.DB.Configuration;

internal class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
{
	public void Configure(EntityTypeBuilder<Technology> builder)
	{
		builder.HasData(
			new Technology { Title = "c++" },
			new Technology { Title = "c#" },
			new Technology { Title = "js" },
			new Technology { Title = "sql" },
			new Technology { Title = "powershell" },
			new Technology { Title = "jira" }
		);
	}
}
