using hr.DB.Enums;

namespace hr.Models.CandidateStatus;

public class UpdateCandidateStatusRequest
{
	public int Id { get; set; }
	public Status Status { get; set; }
}
