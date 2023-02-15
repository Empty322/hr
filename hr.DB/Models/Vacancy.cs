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
	public string Title { get; set; }

	/// <summary>
	/// Описание
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// Технологии
	/// </summary>
	public IEnumerable<Technology> Technologies { get; set; }

}
