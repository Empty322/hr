using hr.Models.Vacancy;

namespace hr.Services.Interfaces
{
	public interface IVacancyService
	{
		VacancyDTO Create(CreateVacancyRequest vacancy);
		VacancyDTO? Get(int id);
		VacancyDTO? Update(VacancyDTO vacancy);
		VacancyDTO? Delete(int id);
	}
}
