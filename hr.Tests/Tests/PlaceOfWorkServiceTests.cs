using AutoMapper;
using hr.AutoMapper;
using hr.Models.Candidate;
using hr.Models.PlaceOfWork;
using hr.Models.Technology;
using hr.Services;
using Microsoft.EntityFrameworkCore;

namespace hr.Tests;

public class PlaceOfWorkServiceTests
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
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);

		var candidate = context.Candidates.Add(TestEntities.Candidate1).Entity;
		context.SaveChanges();
		var createPlaceOfWorkRequest = mapper.Map<CreatePlaceOfWorkRequest>(TestEntities.PlaceOfWork1);
		createPlaceOfWorkRequest.CandidateId = candidate.Id;

		var result = placeOfWorkService.Create(createPlaceOfWorkRequest);
		var createdPlaceOfWork = context.PlacesOfWork.Find(result.Id);

		Assert.That(createPlaceOfWorkRequest.CandidateId, Is.EqualTo(candidate.Id));
		AssertExtensions.AreEqualByJson(createPlaceOfWorkRequest, mapper.Map<CreatePlaceOfWorkRequest>(createdPlaceOfWork));
	}

	[Test]
	public void Get_ShouldReturnEntity()
	{
		using var context = ContextFactory.Create();

		var placeOfWorkId = 1;
		var technologyService = new TechnologyService(context);
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);

		// Database should be seeded
		var placeOfWork = placeOfWorkService.Get(placeOfWorkId);

		Assert.That(placeOfWork, Is.Not.Null);
		Assert.That(placeOfWork.Id, Is.EqualTo(placeOfWorkId));
	}

	[Test]
	public void Get_ShouldReturnNull_IfEntityNotExists()
	{
		using var context = ContextFactory.Create();

		var placeOfWorkId = 0;
		var technologyService = new TechnologyService(context);
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);

		var placeOfWork = placeOfWorkService.Get(placeOfWorkId);

		Assert.That(placeOfWork, Is.Null);
	}

	[Test]
	public void Update_ShouldUpdateEntity()
	{
		using var context = ContextFactory.Create();
		var technologyService = new TechnologyService(context);
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);

		var createCandidateRequest = mapper.Map<CreateCandidateRequest>(TestEntities.Candidate1);
		var createPlaceOfWorkRequest = mapper.Map<CreatePlaceOfWorkRequest>(TestEntities.PlaceOfWork1);
		createPlaceOfWorkRequest.Technologies = new List<TechnologyDTO> {
			new TechnologyDTO { Title = "c#" },
			new TechnologyDTO { Title = "js" }
		};

		var updatePlaceOfWorkRequest = mapper.Map<UpdatePlaceOfWorkRequest>(TestEntities.PlaceOfWork2);
		updatePlaceOfWorkRequest.Technologies = new List<TechnologyDTO> {
			new TechnologyDTO { Title = "c#" },
			new TechnologyDTO { Title = "sql" }
		};

		var createdCandidate = context.Candidates.Add(TestEntities.Candidate1).Entity;
		context.SaveChanges();

		createPlaceOfWorkRequest.CandidateId = createdCandidate.Id;
		var createdPlaceOfWork = placeOfWorkService.Create(createPlaceOfWorkRequest);
		context.ChangeTracker.Clear();

		updatePlaceOfWorkRequest.Id = createdPlaceOfWork.Id;
		var result = placeOfWorkService.Update(updatePlaceOfWorkRequest);

		var updatedPlaceOfWork = context.PlacesOfWork.Find(createdPlaceOfWork.Id);

		Assert.That(result, Is.Not.Null);
		AssertExtensions.AreEqualByJson(updatePlaceOfWorkRequest, mapper.Map<UpdatePlaceOfWorkRequest>(result));
		AssertExtensions.AreEqualByJson(result, mapper.Map<PlaceOfWorkDTO>(updatedPlaceOfWork));
	}

	[Test]
	public void Update_ShouldNotUpdateTechnologies_IfItsNull()
	{
		using var context = ContextFactory.Create();
		var technologyService = new TechnologyService(context);
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);

		var createCandidateRequest = mapper.Map<CreateCandidateRequest>(TestEntities.Candidate1);
		var createPlaceOfWorkRequest = mapper.Map<CreatePlaceOfWorkRequest>(TestEntities.PlaceOfWork1);
		createPlaceOfWorkRequest.Technologies = new List<TechnologyDTO> {
			new TechnologyDTO { Title = "c#" },
			new TechnologyDTO { Title = "js" }
		};

		var updatePlaceOfWorkRequest = mapper.Map<UpdatePlaceOfWorkRequest>(TestEntities.PlaceOfWork2);

		var createdCandidate = context.Candidates.Add(TestEntities.Candidate1).Entity;
		context.SaveChanges();

		createPlaceOfWorkRequest.CandidateId = createdCandidate.Id;
		var createdPlaceOfWork = placeOfWorkService.Create(createPlaceOfWorkRequest);

		updatePlaceOfWorkRequest.Id = createdPlaceOfWork.Id;
		var result = placeOfWorkService.Update(updatePlaceOfWorkRequest);

		var updatedPlaceOfWork = context.PlacesOfWork.Find(createdPlaceOfWork.Id);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Technologies.Select(x => x.Title), Is.EquivalentTo(createPlaceOfWorkRequest.Technologies.Select(x => x.Title)));
		updatePlaceOfWorkRequest.Technologies = createPlaceOfWorkRequest.Technologies;
		AssertExtensions.AreEqualByJson(updatePlaceOfWorkRequest, mapper.Map<UpdatePlaceOfWorkRequest>(result));
		AssertExtensions.AreEqualByJson(result, mapper.Map<PlaceOfWorkDTO>(updatedPlaceOfWork));
	}

	[Test]
	public void Update_ShouldReturnNull_IfEntityNotExists()
	{
		using var context = ContextFactory.Create();
		var technologyService = new TechnologyService(context);
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);
		var updatePlaceOfWorkRequest = mapper.Map<UpdatePlaceOfWorkRequest>(TestEntities.PlaceOfWork1);
		updatePlaceOfWorkRequest.Id = 0;

		var candidate = placeOfWorkService.Update(updatePlaceOfWorkRequest);

		Assert.That(candidate, Is.Null);
	}

	[Test]
	public void Delete_ShouldDeleteEntity()
	{
		using var context = ContextFactory.Create();

		var placeOfWorkId = 1;
		var technologyService = new TechnologyService(context);
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);

		var result = placeOfWorkService.Delete(placeOfWorkId);
		var deletedPlaceOfWork = context.PlacesOfWork.Find(placeOfWorkId);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Id, Is.EqualTo(placeOfWorkId));
		Assert.That(deletedPlaceOfWork, Is.Null);
	}

	[Test]
	public void Delete_ShouldReturnNull_IfEntityNotExists()
	{
		using var context = ContextFactory.Create();

		var placeOfWorkId = 0;
		var technologyService = new TechnologyService(context);
		var placeOfWorkService = new PlaceOfWorkService(context, technologyService, mapper);

		var placeOfWork = placeOfWorkService.Delete(placeOfWorkId);

		Assert.That(placeOfWork, Is.Null);
	}
}