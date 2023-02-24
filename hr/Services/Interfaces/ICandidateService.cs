using hr.Models;
using hr.Models.Candidate;

namespace hr.Services.Interfaces;

public interface ICandidateService: ICRUDService<CreateCandidateRequest, CandidateDTO, CandidateDTO>
{
	PageResult<CandidateDTO> GetSuitable(IEnumerable<string> technologies);
	PageResult<CandidateDTO> GetSuitable(IEnumerable<string> technologies, int pageIndex, int pageItemsCount);
}
