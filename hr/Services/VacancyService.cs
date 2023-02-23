using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.Vacancy;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace hr.Services;

public class VacancyService : IVacancyService
{
	private readonly ApplicationDbContext dbContext;
	private readonly ITechnologyService technologyService;
	private readonly IMapper mapper;

	public VacancyService(ApplicationDbContext dbContext, ITechnologyService technologyService, IMapper mapper)
	{
		this.dbContext = dbContext;
		this.technologyService = technologyService;
		this.mapper = mapper;
	}

	public VacancyDTO Create(CreateVacancyRequest newVacancy)
	{
		if (newVacancy == null)
			throw new ArgumentNullException(nameof(newVacancy));

		if (newVacancy.Technologies != null)
			newVacancy.Technologies = newVacancy.Technologies.GroupBy(x => x.Title).Select(x => x.First());

		var dbVacancy = mapper.Map<Vacancy>(newVacancy);

		dbContext.Vacancies.Add(dbVacancy);

		if (newVacancy.Technologies != null)
			technologyService.SetTechnologyStates(dbVacancy.Technologies);

		dbContext.SaveChanges();

		return mapper.Map<VacancyDTO>(dbVacancy);
	}

	public VacancyDTO? Get(int id)
	{
		var vacancy = dbContext.Vacancies
			.Include(x => x.Technologies)
			.SingleOrDefault(x => x.Id == id);

		return mapper.Map<VacancyDTO>(vacancy);
	}

	public VacancyDTO? Update(VacancyDTO vacancy)
	{
		if (vacancy == null)
			throw new ArgumentNullException(nameof(vacancy));

		var dbVacancy = dbContext.Vacancies
			.Include(x => x.Technologies)
			.SingleOrDefault(x => x.Id == vacancy.Id);

		if (dbVacancy == null)
			return null;

		mapper.Map(vacancy, dbVacancy);

		if (vacancy.Technologies != null)
			technologyService.SetTechnologyStates(dbVacancy.Technologies);

		dbContext.SaveChanges();

		return mapper.Map<VacancyDTO>(dbVacancy);
	}

	public VacancyDTO? Delete(int id)
	{
		var dbVacancy = dbContext.Vacancies
			.Include(x => x.Technologies)
			.SingleOrDefault(x => x.Id == id);

		if (dbVacancy == null)
			return null;

		dbContext.Vacancies.Remove(dbVacancy);

		dbContext.SaveChanges();

		return mapper.Map<VacancyDTO>(dbVacancy);
	}
}
