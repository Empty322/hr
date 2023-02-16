using hr.Models.Candidate;

namespace hr.Services.Interfaces
{
	public interface ICandidateService
	{
		CandidateDTO Create(CreateCandidateRequest candidate);
		CandidateDTO? Get(int id);
		CandidateDTO? Update(CandidateDTO candidate);
		CandidateDTO? Delete(int id);
	}
}
