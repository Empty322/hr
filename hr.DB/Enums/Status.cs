namespace hr.DB.Enums;

/// <summary>
/// Статус рабочего процесса
/// </summary>
public enum Status
{
	/// <summary>
	/// Без образования
	/// </summary>
	New,	

	/// <summary>
	/// Техническое интервью
	/// </summary>
	TechInterview,

	/// <summary>
	/// Интервью с менеджером
	/// </summary>
	ManagerInterview,

	/// <summary>
	/// Сделано предложение
	/// </summary>
	JobOffer,

	/// <summary>
	/// Отказ
	/// </summary>
	Rejection,
}
