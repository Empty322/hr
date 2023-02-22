using hr.Models.CandidateStatus;

namespace hr.Services.Interfaces
{
	public interface ICRUDService<CreateT, UpdateT, T>
	{
		T Create(CreateT createRequest);
		T? Get(int id);
		T? Update(UpdateT updateRequest);
		T? Delete(int id);
	}
}
