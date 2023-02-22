using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.PlaceOfWork.Base;
using hr.Models.Technology;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.PlaceOfWork;

public class UpdatePlaceOfWorkRequest: PlaceOfWorkBaseModel
{
	[Required]
	public int Id { get; set; }
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
