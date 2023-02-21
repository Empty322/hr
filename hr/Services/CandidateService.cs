using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.Technology;
using hr.Services.Interfaces;

namespace hr.Services;

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

		var dbCandidate = mapper.Map<Candidate>(candidateToCreate);

		dbContext.Candidates.Add(dbCandidate);
		dbContext.SaveChanges();

		return mapper.Map<CandidateDTO>(dbCandidate);
	}

	public CandidateDTO? Get(int id)
	{
		var candidate = dbContext.Candidates.Find(id);

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

		mapper.Map(newCandidate, dbCandidate);
		dbContext.SaveChanges();

		return mapper.Map<CandidateDTO>(dbCandidate);
	}

	public CandidateDTO? Delete(int id)
	{
		var dbCandidate = dbContext.Candidates.Find(id);

		if (dbCandidate == null)
			return null;

		dbContext.Candidates.Remove(dbCandidate);

		dbContext.SaveChanges();

		return mapper.Map<CandidateDTO>(dbCandidate);
	}
}
