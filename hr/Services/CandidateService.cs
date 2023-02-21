using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.PlaceOfWork;
using hr.Models.Technology;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace hr.Services;

public class CandidateService : ICandidateService
{
	private readonly ApplicationDbContext dbContext;
	private readonly IPlaceOfWorkService placeOfWorkService;
	private readonly IMapper mapper;

	public CandidateService(ApplicationDbContext dbContext, IPlaceOfWorkService placeOfWorkService, IMapper mapper)
	{
		this.dbContext = dbContext;
		this.placeOfWorkService = placeOfWorkService;
		this.mapper = mapper;
	}

	public CandidateDTO Create(CreateCandidateRequest candidateToCreate)
	{
		if (candidateToCreate == null) 
			throw new ArgumentNullException(nameof(candidateToCreate));

		var placesOfWork = candidateToCreate.PlacesOfWork;
		candidateToCreate.PlacesOfWork = null;

		var candidate = mapper.Map<Candidate>(candidateToCreate);

		dbContext.Candidates.Add(candidate);
		dbContext.SaveChanges();

		var createdPlacesOfWork = new List<PlaceOfWorkDTO>();
		foreach (var placeOfWork in placesOfWork)
		{
			placeOfWork.CandidateId = candidate.Id;
			var createdPlaceOfWork = placeOfWorkService.Create(placeOfWork);
			
			createdPlaceOfWork.Candidate = null;
			createdPlacesOfWork.Add(createdPlaceOfWork);
		}
		var createdCandidate = mapper.Map<CandidateDTO>(candidate);
		createdCandidate.PlacesOfWork = createdPlacesOfWork;

		return createdCandidate;
	}

	public CandidateDTO? Get(int id)
	{
		var candidate = dbContext.Candidates
			.Include(x => x.PlacesOfWork).ThenInclude(x => x.Technologies)
			.SingleOrDefault(x => x.Id == id);

		foreach (var place in candidate.PlacesOfWork)
			place.Candidate = null;

		return mapper.Map<CandidateDTO>(candidate);
	}

	public IEnumerable<CandidateDTO> GetSuitable(IEnumerable<TechnologyDTO> technologies)
	{
		throw new NotImplementedException();
	}
	public CandidateDTO? Update(CandidateDTO newCandidate)
	{
		if (newCandidate == null) 
			throw new ArgumentNullException(nameof(newCandidate));

		var dbCandidate = dbContext.Candidates.Find(newCandidate.Id);
		if (dbCandidate == null)
			return null;

		if (newCandidate.PlacesOfWork != null)
		{
			foreach (var place in newCandidate.PlacesOfWork)
			{
				if (placeOfWorkService.Update(place) == null)
				{
					var createPlaceOfWorkRequest = mapper.Map<CreatePlaceOfWorkRequest>(place);
					createPlaceOfWorkRequest.CandidateId = dbCandidate.Id;
					placeOfWorkService.Create(createPlaceOfWorkRequest);
				}
			}
		}

		newCandidate.PlacesOfWork = null;
		mapper.Map(newCandidate, dbCandidate);
		dbContext.SaveChanges();

		return mapper.Map<CandidateDTO>(dbCandidate);
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
}
