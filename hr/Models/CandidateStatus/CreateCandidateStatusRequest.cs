using hr.DB.Enums;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.CandidateStatus;

public class CreateCandidateStatusRequest
{
	[Required]
	public Status? Status { get; set; }
	[Required]
	public int? CandidateId { get; set; }
	[Required]
	public int? VacancyId { get; set; }
}
