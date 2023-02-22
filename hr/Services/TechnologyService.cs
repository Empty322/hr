using hr.DB;
using hr.DB.Models;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace hr.Services;

public class TechnologyService : ITechnologyService
{
	private readonly ApplicationDbContext dbContext;

	public TechnologyService(ApplicationDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public void SetTechnologyStates(List<TechnologyPlaceOfWork> technologies)
	{
		if (technologies == null)
			throw new ArgumentNullException(nameof(technologies));

		foreach (var tech in technologies)
		{
			if (tech.Technology == null) throw new ArgumentNullException(nameof(tech.Technology));

			if (dbContext.Technologies.Any(x => x.Title == tech.TechnologyTitle))
				dbContext.Entry(tech.Technology).State = EntityState.Unchanged;
			else
				dbContext.Entry(tech.Technology).State = EntityState.Added;
		}
	}

	public void SetTechnologyStates(List<TechnologyVacancy> technologies)
	{
		if (technologies == null)
			throw new ArgumentNullException(nameof(technologies));

		foreach (var tech in technologies)
		{
			if (tech.Technology == null) throw new ArgumentNullException(nameof(tech.Technology));

			if (dbContext.Technologies.Any(x => x.Title == tech.TechnologyTitle))
				dbContext.Entry(tech.Technology).State = EntityState.Unchanged;
			else
				dbContext.Entry(tech.Technology).State = EntityState.Added;
		}
	}
}
