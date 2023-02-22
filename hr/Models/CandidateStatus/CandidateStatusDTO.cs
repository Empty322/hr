using hr.DB.Enums;

namespace hr.Models.CandidateStatus;

public class CandidateStatusDTO
{
	public int Id { get; set; }
	public Status Status { get; set; }
	public int CandidateId { get; set; }
	public int VacancyId { get; set; }
}
