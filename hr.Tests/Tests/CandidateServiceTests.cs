using AutoMapper;
using hr.AutoMapper;
using hr.DB.Enums;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Services;

namespace hr.Tests
{
	public class CandidateServiceTests
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
			var candidateService = new CandidateService(context, mapper);
			var createCandidateRequest = mapper.Map<CreateCandidateRequest>(TestEntities.Candidate1);

			var result = candidateService.Create(createCandidateRequest);
			var createdCandidate = context.Candidates.Find(result.Id);

			AssertExtensions.AreEqualByJson(createCandidateRequest, mapper.Map<CreateCandidateRequest>(createdCandidate));
		}

		[Test]
		public void Get_ShouldReturnEntity()
		{
			using var context = ContextFactory.Create();
			var candidateId = 1;
			var candidateService = new CandidateService(context, mapper);

			// Database should be seeded
			var candidate = candidateService.Get(candidateId);

			Assert.That(candidate, Is.Not.Null);
			Assert.That(candidate.Id, Is.EqualTo(candidateId));
		}

		[Test]
		public void Get_ShouldReturnNull_IfEntityNotExists()
		{
			using var context = ContextFactory.Create();
			var candidateId = 0;
			var candidateService = new CandidateService(context, mapper);

			var candidate = candidateService.Get(candidateId);

			Assert.That(candidate, Is.Null);
		}

		[Test]
		public void Update_ShouldUpdateEntity()
		{
			using var context = ContextFactory.Create();
			var createCandidateRequest = mapper.Map<CreateCandidateRequest>(TestEntities.Candidate1);
			var updateCandidateRequest = mapper.Map<CandidateDTO>(TestEntities.Candidate2);
			var candidateService = new CandidateService(context, mapper);

			var createdCandidate = candidateService.Create(createCandidateRequest);
			updateCandidateRequest.Id = createdCandidate.Id;
			var result = candidateService.Update(updateCandidateRequest);
			var updatedCandidate = context.Candidates.Find(createdCandidate.Id);

			Assert.That(result, Is.Not.Null);
			AssertExtensions.AreEqualByJson(updateCandidateRequest, result);
			AssertExtensions.AreEqualByJson(result, mapper.Map<CandidateDTO>(updatedCandidate));
		}

		[Test]
		public void Update_ShouldReturnNull_IfEntityNotExists()
		{
			using var context = ContextFactory.Create();
			var updateCandidateRequest = mapper.Map<CandidateDTO>(TestEntities.Candidate2);
			updateCandidateRequest.Id = 0;
			var candidateService = new CandidateService(context, mapper);

			var candidate = candidateService.Update(updateCandidateRequest);

			Assert.That(candidate, Is.Null);
		}

		[Test]
		public void Delete_ShouldDeleteEntity()
		{
			using var context = ContextFactory.Create();
			var candidateId = 1;
			var candidateService = new CandidateService(context, mapper);

			var result = candidateService.Delete(candidateId);
			var deletedCandidate = context.Candidates.Find(candidateId);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Id, Is.EqualTo(candidateId));
			Assert.That(deletedCandidate, Is.Null);
		}

		[Test]
		public void Delete_ShouldReturnNull_IfEntityNotExists()
		{
			using var context = ContextFactory.Create();
			var candidateId = 0;
			var candidateService = new CandidateService(context, mapper);

			var candidate = candidateService.Delete(candidateId);

			Assert.That(candidate, Is.Null);
		}

		[Test]
		public void GetSuitable_ShouldReturnCandidates_ThatHaveAllTechnologiesInTheirPlacesOfWork()
		{
			using var context = ContextFactory.Create();
			var firstStack = new List<string> { "sql" };
			var secondStack = new List<string> { "mysql", "js", "ts" };
			var thirdStack = new List<string> { "sql", "powershell" };
			var candidateService = new CandidateService(context, mapper);

			// Database should be seeded
			var firstStackSuitable = candidateService.GetSuitable(firstStack);
			var secondStackSuitable = candidateService.GetSuitable(secondStack);
			var thirdStackSuitable = candidateService.GetSuitable(thirdStack);

			Assert.That(
				firstStackSuitable.Result.Select(x => x.Id),
				Is.EquivalentTo(new List<int> { 1, 2, 3 }));
			Assert.That(
				secondStackSuitable.Result.Select(x => x.Id),
				Is.EquivalentTo(new List<int> { }));
			Assert.That(
				thirdStackSuitable.Result.Select(x => x.Id),
				Is.EquivalentTo(new List<int> { 2 }));
		}

		[Test]
		public void GetSuitable_ShouldReturnCandidates_ThatHaveAllTechnologiesInTheirPlacesOfWork_OnSpecifiedPage()
		{
			using var context = ContextFactory.Create();
			var firstStack = new List<string> { "sql" };
			var candidateService = new CandidateService(context, mapper);

			// Database should be seeded
			var firstStackSuitable = candidateService.GetSuitable(firstStack, 1, 1);

			Assert.That(
				firstStackSuitable.Result.Select(x => x.Id),
				Is.EquivalentTo(new List<int> { 2 }));
		}
	}
}