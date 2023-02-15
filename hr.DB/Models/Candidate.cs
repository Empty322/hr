using hr.DB.Enums;

namespace hr.DB.Models;

/// <summary>
/// Кандидат
/// </summary>
public class Candidate
{
	public int Id { get; set; }

	/// <summary>
	/// ФИО кандидата
	/// </summary>
	public string FullName { get; set; }

	/// <summary>
	/// Дата рождения
	/// </summary>
	public DateTime? DateOfBirth { get; set; }

	/// <summary>
	/// Образование
	/// </summary>
	public Education Education { get; set; }

	/// <summary>
	/// Университет
	/// </summary>
	public string University { get; set; }

	/// <summary>
	/// Факультет
	/// </summary>
	public string Faculty { get; set; }

	/// <summary>
	/// Места работы
	/// </summary>
	public IEnumerable<PlaceOfWork> PlacesOfWork { get; set; }
}
