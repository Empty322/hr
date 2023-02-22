using hr.DB.Models;
using hr.Models.PlaceOfWork.Base;
using hr.Models.Technology;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.PlaceOfWork;

public class CreatePlaceOfWorkRequest : PlaceOfWorkBaseModel
{
	
	[Required]
	public int CandidateId { get; set; }
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
