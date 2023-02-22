using hr.Models.Candidate;
using hr.Models.PlaceOfWork;

namespace hr.Services.Interfaces
{
	public interface IPlaceOfWorkService : ICRUDService<CreatePlaceOfWorkRequest, UpdatePlaceOfWorkRequest, PlaceOfWorkDTO>
	{
	}
}
