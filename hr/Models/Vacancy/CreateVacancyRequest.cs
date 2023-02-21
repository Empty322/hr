using hr.DB.Enums;
using hr.Models.Technology;

namespace hr.Models.Vacancy;

public class CreateVacancyRequest
{
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public IEnumerable<TechnologyDTO>? Technologies { get; set; }
}
