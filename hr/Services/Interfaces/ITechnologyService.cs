using hr.DB.Models;

namespace hr.Services.Interfaces
{
	public interface ITechnologyService
	{
		void SetTechnologyStates(List<TechnologyPlaceOfWork> technologies);
		void SetTechnologyStates(List<TechnologyVacancy> technologies);
	}
}
