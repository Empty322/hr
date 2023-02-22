using hr.DB.Enums;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.CandidateStatus;

public class UpdateCandidateStatusRequest
{
	[Required]
	public int Id { get; set; }
	[Required]
	public Status? Status { get; set; }
}
