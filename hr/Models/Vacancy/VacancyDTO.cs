using hr.Models.Technology;

namespace hr.Models.Vacancy;

public class VacancyDTO
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public List<TechnologyDTO>? Technologies { get; set; }
}
