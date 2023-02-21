using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.PlaceOfWork;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace hr.Services
{
	public class PlaceOfWorkService : IPlaceOfWorkService
	{
		private readonly ApplicationDbContext dbContext;
		private readonly ITechnologyService technologyService;
		private readonly IMapper mapper;

		public PlaceOfWorkService(ApplicationDbContext dbContext, ITechnologyService technologyService, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.technologyService = technologyService;
			this.mapper = mapper;
		}

		public PlaceOfWorkDTO Create(CreatePlaceOfWorkRequest placeOfWorkRequest)
		{
			if (placeOfWorkRequest == null)
				throw new ArgumentNullException(nameof(placeOfWorkRequest));

			if (placeOfWorkRequest.Technologies != null)
				placeOfWorkRequest.Technologies = placeOfWorkRequest.Technologies.GroupBy(x => x.Title).Select(x => x.First());

			var dbPlaceOfWork = mapper.Map<PlaceOfWork>(placeOfWorkRequest);
			
			dbContext.PlacesOfWork.Add(dbPlaceOfWork);

			if (dbPlaceOfWork.Technologies != null)
				technologyService.SetTechnologyStates(dbPlaceOfWork.Technologies);

			dbContext.SaveChanges();
			dbContext.ChangeTracker.Clear();

			return mapper.Map<PlaceOfWorkDTO>(dbPlaceOfWork);
		}

		public PlaceOfWorkDTO? Get(int id)
		{
			var placeOfWork = dbContext.PlacesOfWork
				.Include(x => x.Technologies)
				.SingleOrDefault(x => x.Id == id);

			return mapper.Map<PlaceOfWorkDTO>(placeOfWork);
		}

		public PlaceOfWorkDTO? Update(PlaceOfWorkDTO placeOfWork)
		{
			if (placeOfWork == null)
				throw new ArgumentNullException(nameof(placeOfWork));

			var dbPlaceOfWork = dbContext.PlacesOfWork
				.Include(x => x.Technologies)
				.SingleOrDefault(x => x.Id == placeOfWork.Id);

			if (dbPlaceOfWork == null)
				return null;

			if (placeOfWork.Technologies != null)
				placeOfWork.Technologies = placeOfWork.Technologies.GroupBy(x => x.Title).Select(x => x.First());

			mapper.Map(placeOfWork, dbPlaceOfWork);
			
			if (dbPlaceOfWork.Technologies != null)
				technologyService.SetTechnologyStates(dbPlaceOfWork.Technologies);

			dbContext.SaveChanges();

			return mapper.Map<PlaceOfWorkDTO>(dbPlaceOfWork);
		}

		public PlaceOfWorkDTO? Delete(int id)
		{
			var placeOfWork = dbContext.PlacesOfWork
				.Include(x => x.Technologies)
				.SingleOrDefault(x => x.Id == id);

			if (placeOfWork == null)
				return null;

			dbContext.PlacesOfWork.Remove(placeOfWork);

			dbContext.SaveChanges();

			return mapper.Map<PlaceOfWorkDTO>(placeOfWork);
		}
	}
}
