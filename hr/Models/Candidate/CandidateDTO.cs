using hr.DB.Enums;
using hr.Models.PlaceOfWork;

namespace hr.Models.Candidate;

public class CandidateDTO
{
	public int Id { get; set; }
	public string FullName { get; set; } = string.Empty;
	public DateTime DateOfBirth { get; set; }
	public Education Education { get; set; }
	public string University { get; set; } = string.Empty;
	public string Faculty { get; set; } = string.Empty;
}
