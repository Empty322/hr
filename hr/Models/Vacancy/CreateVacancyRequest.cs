using hr.DB.Enums;
using hr.Models.Technology;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.Vacancy;

public class CreateVacancyRequest
{
	[Required]
	public string Title { get; set; } = string.Empty;
	[Required]
	public string Description { get; set; } = string.Empty;
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
