using hr.DB.Models;
using hr.Models.Technology;

namespace hr.Models.PlaceOfWork;

public class CreatePlaceOfWorkRequest
{
	public DateTime Begin { get; set; }
	public DateTime End { get; set; }
	public string Company { get; set; } = string.Empty;
	public string Position { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int CandidateId { get; set; }
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
