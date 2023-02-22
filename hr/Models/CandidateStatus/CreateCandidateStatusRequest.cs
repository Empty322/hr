using hr.DB.Enums;

namespace hr.Models.CandidateStatus;

public class CreateCandidateStatusRequest
{
	public Status Status { get; set; }
	public int CandidateId { get; set; }
	public int VacancyId { get; set; }
}
