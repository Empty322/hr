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
	public DateTime Begin { get; set; }

	/// <summary>
	/// Дата окончания работы
	/// </summary>
	public DateTime End { get; set; }

	/// <summary>
	/// Название компании
	/// </summary>
	public string Company { get; set; } = string.Empty;

	/// <summary>
	/// Занимаемая должность
	/// </summary>
	public string Position { get; set; } = string.Empty;

	/// <summary>
	/// Описание
	/// </summary>
	public string Description { get; set; } = string.Empty;

	public int CandidateId { get; set; }
	/// <summary>
	/// Кандидат
	/// </summary>
	public Candidate? Candidate { get; set; }

	/// <summary>
	/// Список технологий
	/// </summary>
	public List<TechnologyPlaceOfWork>? Technologies { get; set; }


}
