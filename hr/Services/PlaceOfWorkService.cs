using AutoMapper;
using hr.DB;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.PlaceOfWork;
using hr.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace hr.Services
{
	public class PlaceOfWorkService : IPlaceOfWorkService
	{
		private readonly ApplicationDbContext dbContext;
		private readonly IMapper mapper;

		public PlaceOfWorkService(ApplicationDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
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
				SetTechnologyStates(dbPlaceOfWork.Technologies);

			dbContext.SaveChanges();

			return mapper.Map<PlaceOfWorkDTO>(dbPlaceOfWork);
		}

		public PlaceOfWorkDTO? Get(int id)
		{
			var placeOfWork = dbContext.PlacesOfWork
				.Include(x => x.Technologies).ThenInclude(x => x.Technology)
				.SingleOrDefault(x => x.Id == id);

			return mapper.Map<PlaceOfWorkDTO>(placeOfWork);
		}

		public PlaceOfWorkDTO? Update(PlaceOfWorkDTO placeOfWork)
		{
			if (placeOfWork == null)
				throw new ArgumentNullException(nameof(placeOfWork));

			var dbPlaceOfWork = dbContext.PlacesOfWork
				.SingleOrDefault(x => x.Id == placeOfWork.Id);

			if (dbPlaceOfWork == null)
				return null;

			if (placeOfWork.Technologies != null)
			{
				placeOfWork.Technologies = placeOfWork.Technologies.GroupBy(x => x.Title).Select(x => x.First());
				dbContext.Entry(dbPlaceOfWork).Collection(x => x.Technologies).Load();
			}

			mapper.Map(placeOfWork, dbPlaceOfWork);
			
			if (dbPlaceOfWork.Technologies != null)
				SetTechnologyStates(dbPlaceOfWork.Technologies);

			dbContext.ChangeTracker.DetectChanges();
			dbContext.SaveChanges();

			return mapper.Map<PlaceOfWorkDTO>(dbPlaceOfWork);
		}

		public PlaceOfWorkDTO? Delete(int id)
		{
			var placeOfWork = dbContext.PlacesOfWork.Find(id);

			if (placeOfWork == null)
				return null;

			dbContext.PlacesOfWork.Remove(placeOfWork);

			dbContext.SaveChanges();

			return mapper.Map<PlaceOfWorkDTO>(placeOfWork);
		}

		private void SetTechnologyStates(List<TechnologyPlaceOfWork> technologies)
		{
			if (technologies == null)
				throw new ArgumentNullException(nameof(technologies));

			foreach (var tech in technologies)
			{
				if (tech.Technology == null) throw new ArgumentNullException(nameof(tech.Technology));

				if (dbContext.Technologies.Any(x => x.Title == tech.TechnologyTitle))
					dbContext.Entry(tech.Technology).State = EntityState.Unchanged;
				else
					dbContext.Entry(tech.Technology).State = EntityState.Added;
			}
		}
	}
}
