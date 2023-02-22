using hr.Models.Vacancy;

namespace hr.Services.Interfaces;

public interface IVacancyService : ICRUDService<CreateVacancyRequest, VacancyDTO, VacancyDTO>
{
}
