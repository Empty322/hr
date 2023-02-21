namespace hr.DB.Models;

public class TechnologyVacancy
{
	public string TechnologyTitle { get; set; } = string.Empty;
	public Technology? Technology { get; set; }
	public int VacancyId { get; set; }
	public Vacancy? Vacancy { get; set; }
}
