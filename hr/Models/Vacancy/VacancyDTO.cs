using hr.Models.Technology;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.Vacancy;

public class VacancyDTO
{
	[Required]
	public int Id { get; set; }
	[Required]
	public string Title { get; set; } = string.Empty;
	[Required]
	public string Description { get; set; } = string.Empty;
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
