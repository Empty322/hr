namespace hr.DB.Models;

/// <summary>
/// Место работы
/// </summary>
public class PlaceOfWork
{
	public int Id { get; set; }

	/// <summary>
	/// Дата начала работы
	/// </summary>
	public DateOnly Begin { get; set; }

	/// <summary>
	/// Дата окончания работы
	/// </summary>
	public DateOnly End { get; set; }

	/// <summary>
	/// Название компании
	/// </summary>
	public string Company { get; set; }

	/// <summary>
	/// Занимаемая должность
	/// </summary>
	public string Position { get; set; }

	/// <summary>
	/// Описание
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// Список технологий
	/// </summary>
	public IEnumerable<Technology> Technologies { get; set; }
}
