using hr.Models.PlaceOfWork.Base;
using hr.Models.Technology;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.PlaceOfWork;

public class PlaceOfWorkDTO : PlaceOfWorkBaseModel
{
	[Required]
	public int Id { get; set; }
	[Required]
	public int CandidateId { get; set; }
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
