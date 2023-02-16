namespace hr.DB.Models;

/// <summary>
/// Вакансия
/// </summary>
public class Vacancy
{
	public int Id { get; set; }

	/// <summary>
	/// Наименование
	/// </summary>
	public string Title { get; set; } = string.Empty;

	/// <summary>
	/// Описание
	/// </summary>
	public string Description { get; set; } = string.Empty;

	/// <summary>
	/// Технологии
	/// </summary>
	public List<Technology>? Technologies { get; set; }

}
