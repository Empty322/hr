using AutoMapper;
using hr.AutoMapper;
using hr.DB.Enums;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.Vacancy;
using hr.Models.Technology;
using hr.Services;
using Microsoft.EntityFrameworkCore;

namespace hr.Tests;

public class VacancyServiceTests
{
	private IMapper mapper;

	[SetUp]
	public void Setup()
	{
		var config = new MapperConfiguration(cfg => {
			cfg.AddProfile<AutoMapperProfile>();
		});
		mapper = new Mapper(config);
	}

	[Test]
	public void Create_ShouldAddEntity()
	{
		using var context = ContextFactory.Create();
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);

		var createVacancyRequest = mapper.Map<CreateVacancyRequest>(TestEntities.Vacancy1);
		createVacancyRequest.Technologies = new List<TechnologyDTO> {
			new TechnologyDTO { Title = "c++" },
			new TechnologyDTO { Title = "sql" }
		};

		var result = vacancyService.Create(createVacancyRequest);
		var createdVacancy = context.Vacancies.Find(result.Id);

		AssertExtensions.AreEqualByJson(createVacancyRequest, mapper.Map<CreateVacancyRequest>(createdVacancy));
	}

	[Test]
	public void Get_ShouldReturnEntity()
	{
		using var context = ContextFactory.Create();

		var vacancyId = 1;
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);

		// Database should be seeded
		var vacancy = vacancyService.Get(vacancyId);

		Assert.That(vacancy, Is.Not.Null);
		Assert.That(vacancy.Id, Is.EqualTo(vacancyId));
	}

	[Test]
	public void Get_ShouldReturnNull_IfEntityNotExists()
	{
		using var context = ContextFactory.Create();

		var vacancyId = 0;
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);

		var vacancy = vacancyService.Get(vacancyId);

		Assert.That(vacancy, Is.Null);
	}

	[Test]
	public void Update_ShouldUpdateEntity()
	{
		using var context = ContextFactory.Create();
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);

		var createVacancyRequest = mapper.Map<CreateVacancyRequest>(TestEntities.Vacancy1);
		createVacancyRequest.Technologies = new List<TechnologyDTO> {
			new TechnologyDTO { Title = "c#" },
			new TechnologyDTO { Title = "js" }
		};

		var updateVacancyRequest = mapper.Map<VacancyDTO>(TestEntities.Vacancy2);
		updateVacancyRequest.Technologies = new List<TechnologyDTO> {
			new TechnologyDTO { Title = "c#" },
			new TechnologyDTO { Title = "sql" }
		};

		var createdVacancy = vacancyService.Create(createVacancyRequest);
		context.ChangeTracker.Clear();

		updateVacancyRequest.Id = createdVacancy.Id;
		var result = vacancyService.Update(updateVacancyRequest);

		var updatedVacancy = context.Vacancies.Find(createdVacancy.Id);

		Assert.That(result, Is.Not.Null);
		AssertExtensions.AreEqualByJson(updateVacancyRequest, mapper.Map<VacancyDTO>(result));
		AssertExtensions.AreEqualByJson(result, mapper.Map<VacancyDTO>(updatedVacancy));
	}

	[Test]
	public void Update_ShouldNotUpdateTechnologies_IfItsNull()
	{
		using var context = ContextFactory.Create();
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);

		var createCandidateRequest = mapper.Map<CreateCandidateRequest>(TestEntities.Candidate1);
		var createVacancyRequest = mapper.Map<CreateVacancyRequest>(TestEntities.Vacancy1);
		createVacancyRequest.Technologies = new List<TechnologyDTO> {
			new TechnologyDTO { Title = "c#" },
			new TechnologyDTO { Title = "js" }
		};

		var updateVacancyRequest = mapper.Map<VacancyDTO>(TestEntities.Vacancy2);

		var createdVacancy = vacancyService.Create(createVacancyRequest);
		context.ChangeTracker.Clear();

		updateVacancyRequest.Id = createdVacancy.Id;
		var result = vacancyService.Update(updateVacancyRequest);

		var updatedVacancy = context.Vacancies.Find(createdVacancy.Id);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Technologies.Select(x => x.Title), Is.EquivalentTo(createVacancyRequest.Technologies.Select(x => x.Title)));
		updateVacancyRequest.Technologies = createVacancyRequest.Technologies;
		AssertExtensions.AreEqualByJson(updateVacancyRequest, mapper.Map<VacancyDTO>(result));
		AssertExtensions.AreEqualByJson(result, mapper.Map<VacancyDTO>(updatedVacancy));
	}

	[Test]
	public void Update_ShouldReturnNull_IfEntityNotExists()
	{
		using var context = ContextFactory.Create();
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);
		var updateVacancyRequest = mapper.Map<VacancyDTO>(TestEntities.Vacancy1);
		updateVacancyRequest.Id = 0;

		var candidate = vacancyService.Update(updateVacancyRequest);

		Assert.That(candidate, Is.Null);
	}

	[Test]
	public void Delete_ShouldDeleteEntity()
	{
		using var context = ContextFactory.Create();

		var vacancyId = 1;
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);

		var result = vacancyService.Delete(vacancyId);
		var deletedVacancy = context.Vacancies.Find(vacancyId);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Id, Is.EqualTo(vacancyId));
		Assert.That(deletedVacancy, Is.Null);
	}

	[Test]
	public void Delete_ShouldReturnNull_IfEntityNotExists()
	{
		using var context = ContextFactory.Create();

		var vacancyId = 0;
		var technologyService = new TechnologyService(context);
		var vacancyService = new VacancyService(context, technologyService, mapper);

		var vacancy = vacancyService.Delete(vacancyId);

		Assert.That(vacancy, Is.Null);
	}
}