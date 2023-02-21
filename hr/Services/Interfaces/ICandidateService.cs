using hr.Models.Candidate;
using hr.Models.Technology;

namespace hr.Services.Interfaces
{
	public interface ICandidateService
	{
		CandidateDTO Create(CreateCandidateRequest candidate);
		CandidateDTO? Get(int id);
		IEnumerable<CandidateDTO> GetSuitable(IEnumerable<TechnologyDTO> technologies);
		CandidateDTO? Update(CandidateDTO candidate);
		CandidateDTO? Delete(int id);
	}
}
