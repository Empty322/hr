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
	public string FullName { get; set; } = string.Empty;

	/// <summary>
	/// Дата рождения
	/// </summary>
	public DateTime DateOfBirth { get; set; }

	/// <summary>
	/// Образование
	/// </summary>
	public Education Education { get; set; }

	/// <summary>
	/// Университет
	/// </summary>
	public string University { get; set; } = string.Empty;

	/// <summary>
	/// Факультет
	/// </summary>
	public string Faculty { get; set; } = string.Empty;

	/// <summary>
	/// Места работы
	/// </summary>
	public List<PlaceOfWork>? PlacesOfWork { get; set; }

	/// <summary>
	/// Рабочие процессы кандидата
	/// </summary>
	public List<CandidateStatus>? CandidateStatuses { get; set; }
}
