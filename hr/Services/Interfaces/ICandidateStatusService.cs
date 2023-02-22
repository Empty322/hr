using hr.Models.CandidateStatus;

namespace hr.Services.Interfaces
{
	public interface ICandidateStatusService : ICRUDService<CreateCandidateStatusRequest, UpdateCandidateStatusRequest, CandidateStatusDTO>
	{
	}
}
