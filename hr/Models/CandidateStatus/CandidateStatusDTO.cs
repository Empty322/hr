using hr.DB.Enums;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.CandidateStatus;

public class CandidateStatusDTO
{
	[Required]
	public int Id { get; set; }
	[Required]
	public Status? Status { get; set; }
	[Required]
	public int CandidateId { get; set; }
	[Required]
	public int VacancyId { get; set; }
}
