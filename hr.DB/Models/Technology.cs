using System.ComponentModel.DataAnnotations;

namespace hr.DB.Models;

/// <summary>
/// Технология
/// </summary>
public class Technology
{
	/// <summary>
	/// Наименование
	/// </summary>
	[Key]
	public string Title { get; set; } = string.Empty;
	public List<TechnologyVacancy>? Vacancies { get; set; }
	public List<TechnologyPlaceOfWork>? PlacesOfWork { get; set; }
}
