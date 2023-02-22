using hr.Models.Candidate;
using hr.Models.Technology;

namespace hr.Services.Interfaces;

public interface ICandidateService: ICRUDService<CreateCandidateRequest, CandidateDTO, CandidateDTO>
{
	IEnumerable<CandidateDTO> GetSuitable(IEnumerable<TechnologyDTO> technologies);
}
