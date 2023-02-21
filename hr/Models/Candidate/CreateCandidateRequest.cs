using hr.DB.Enums;

namespace hr.Models.Candidate;

public class CreateCandidateRequest
{
	public string FullName { get; set; } = string.Empty;
	public DateTime DateOfBirth { get; set; }
	public Education Education { get; set; }
	public string University { get; set; } = string.Empty;
	public string Faculty { get; set; } = string.Empty;
}
