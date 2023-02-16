using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace hr.Services
{
	public class CandidateService : ICandidateService
	{
		private readonly ApplicationDbContext dbContext;
		private readonly IMapper mapper;

		public CandidateService(ApplicationDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public CandidateDTO Create(CreateCandidateRequest candidateToCreate)
		{
			if (candidateToCreate == null) 
				throw new ArgumentNullException(nameof(candidateToCreate));

			var candidate = mapper.Map<Candidate>(candidateToCreate);
			dbContext.Candidates.Add(candidate);

			if (candidate.PlacesOfWork != null)
				foreach (var place in candidate.PlacesOfWork)
					foreach (var tech in place.Technologies)
						if (dbContext.Technologies.Any(x => x.Title == tech.TechnologyTitle))
							dbContext.Entry(tech).State = EntityState.Unchanged;

			dbContext.SaveChanges();

			return mapper.Map<CandidateDTO>(candidate);
		}

		public CandidateDTO? Delete(int id)
		{
			var candidate = dbContext.Candidates.Find(id);

			if (candidate == null)
				return null;

			dbContext.Candidates.Remove(candidate);

			dbContext.SaveChanges();

			return mapper.Map<CandidateDTO>(candidate);
		}

		public CandidateDTO? Get(int id)
		{
			var candidate = dbContext.Candidates
				.Include(x => x.PlacesOfWork).ThenInclude(x => x.Technologies)
				.SingleOrDefault(x => x.Id == id);

			return mapper.Map<CandidateDTO>(candidate);
		}

		public CandidateDTO? Update(CandidateDTO newCandidate)
		{
			throw new NotImplementedException();

			if (newCandidate == null) 
				throw new ArgumentNullException(nameof(newCandidate));

			var candidate = dbContext.Candidates.Find(newCandidate.Id);
			if (candidate == null)
				return null;

			mapper.Map(newCandidate, candidate);
			var placesOfWork = candidate.PlacesOfWork;
			candidate.PlacesOfWork = null;
			dbContext.SaveChanges();

			//foreach (var place in placesOfWork)
			//{
			//	var technologies = place.Technologies;
			//	place.Technologies = null;

			//	var dbPlace = dbContext.PlacesOfWork.Find(place.Id);
			//	if (dbPlace != null)
			//	{
			//		mapper.Map(place, dbPlace);
			//		dbPlace.Candidate = candidate;
			//	}
			//	else
			//	{
			//		place.Candidate = candidate;
			//		dbContext.PlacesOfWork.Add(place);
			//	}
			//	dbContext.SaveChanges();

			//	foreach (var tech in technologies)
			//	{
			//		var dbTech = dbContext.Technologies.Find(tech.TechnologyTitle);
			//		if (dbTech != null)
			//		{
			//			dbTech.PlacesOfWork.Add(place);
			//		}
			//		else
			//		{
			//			tech.place.Add(place);
			//			dbContext.Technologies.Add(tech);
			//		}
			//	}
			//	dbContext.SaveChanges();
			//}

			return mapper.Map<CandidateDTO>(candidate);
		}
	}
}
