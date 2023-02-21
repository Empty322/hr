using AutoMapper;
using hr.AutoMapper;
using hr.DB;
using hr.DB.Enums;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.PlaceOfWork;
using hr.Models.Technology;
using hr.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

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
		public void Create_SavesEntityInDB()
		{
			var context = ContextFactory.Create();
			var placesOfWorkService = new PlaceOfWorkService(context.Object, mapper);
			var candidateService = new CandidateService(context.Object, placesOfWorkService, mapper);
			var candidate = new CreateCandidateRequest {
				FullName = "misha",
				DateOfBirth = new DateTime(2000, 1, 1),
				Education = Education.SecondarySpecialized,
				University = "my university",
				Faculty = "my faculty",
				PlacesOfWork = new List<CreatePlaceOfWorkRequest>()
				  {
					  new CreatePlaceOfWorkRequest {
						Begin = new DateTime(2005, 02, 15),
						End = new DateTime(2008, 02, 15),
						Company = "company name",
						Position = "my position",
						Description = "description",
						Technologies = new List<TechnologyDTO>() {
					  		new TechnologyDTO { Title = "c++" },
					  		new TechnologyDTO { Title = "js" }
					    }
					  }
	}
			};
			
			candidateService.Create(candidate);

			var added = context.Object.Candidates.Single(c => c.FullName == candidate.FullName);

			Assert.That(added, Is.EqualTo(mapper.Map<Candidate>(candidate)));
		}
	}
}