using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.Technology;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

	public IEnumerable<CandidateDTO> GetSuitable(IEnumerable<string> requiredTechnologies)
	{
		// Получаем всех кандидатов
		var allCandidates = dbContext.Candidates
			.Include(x => x.PlacesOfWork).ThenInclude(x => x.Technologies);

		// Подходящие кандидаты
		var suitableCandidates = new List<CandidateDTO>();

		foreach (var candidate in allCandidates)
		{
			// Технологии, которыме были у кандидата на местах работы
			var candidateTechnologies = candidate.PlacesOfWork
				.SelectMany(x => x.Technologies).Select(x => x.TechnologyTitle)
				.ToList();

			// Если кандидат владеет всеми нужными технологиями
			if (requiredTechnologies.All(x => candidateTechnologies.Contains(x)))
				suitableCandidates.Add(mapper.Map<CandidateDTO>(candidate));
		}

		return suitableCandidates;
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
