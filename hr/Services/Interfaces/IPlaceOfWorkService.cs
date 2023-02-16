using hr.Models.Candidate;
using hr.Models.PlaceOfWork;

namespace hr.Services.Interfaces
{
	public interface IPlaceOfWorkService
	{
		PlaceOfWorkDTO Create(CreatePlaceOfWorkRequest placeOfWork);
		PlaceOfWorkDTO? Get(int id);
		PlaceOfWorkDTO? Update(PlaceOfWorkDTO placeOfWork);
		PlaceOfWorkDTO? Delete(int id);
	}
}
