using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.Technology;

namespace hr.Models.PlaceOfWork;

public class PlaceOfWorkDTO
{
	public int Id { get; set; }
	public DateTime Begin { get; set; }
	public DateTime End { get; set; }
	public string Company { get; set; } = string.Empty;
	public string Position { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int CandidateId { get; set; }
	public CandidateDTO? Candidate { get; set; }
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
