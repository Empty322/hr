using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.CandidateStatus;
using hr.Services.Interfaces;

namespace hr.Services;

public class CandidateStatusService : ICandidateStatusService
{
	private readonly ApplicationDbContext dbContext;
	private readonly IMapper mapper;

	public CandidateStatusService(ApplicationDbContext dbContext, IMapper mapper)
	{
		this.dbContext = dbContext;
		this.mapper = mapper;
	}
	public CandidateStatusDTO Create(CreateCandidateStatusRequest newStatus)
	{
		if (newStatus == null)
			throw new ArgumentNullException(nameof(newStatus));

		var dbStatus = mapper.Map<CandidateStatus>(newStatus);

		dbContext.CandidateStatuses.Add(dbStatus);
		dbContext.SaveChanges();

		return mapper.Map<CandidateStatusDTO>(dbStatus);
	}

	public CandidateStatusDTO? Get(int id)
	{
		var candidate = dbContext.CandidateStatuses.Find(id);

		return mapper.Map<CandidateStatusDTO>(candidate);
	}

	public CandidateStatusDTO? Update(UpdateCandidateStatusRequest updatedStatus)
	{
		if (updatedStatus == null)
			throw new ArgumentNullException(nameof(updatedStatus));

		var dbCandidateStatus = dbContext.CandidateStatuses.Find(updatedStatus.Id);
		if (dbCandidateStatus == null)
			return null;

		mapper.Map(updatedStatus, dbCandidateStatus);
		dbContext.SaveChanges();

		return mapper.Map<CandidateStatusDTO>(dbCandidateStatus);
	}

	public CandidateStatusDTO? Delete(int id)
	{
		var dbCandidateStatus = dbContext.CandidateStatuses.Find(id);

		if (dbCandidateStatus == null)
			return null;

		dbContext.CandidateStatuses.Remove(dbCandidateStatus);

		dbContext.SaveChanges();

		return mapper.Map<CandidateStatusDTO>(dbCandidateStatus);
	}
}
