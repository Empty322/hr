using AutoMapper;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.PlaceOfWork;
using hr.Models.Technology;

namespace hr.AutoMapper
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Candidate, CandidateDTO>().ReverseMap();
			CreateMap<Candidate, CreateCandidateRequest>().ReverseMap();

			CreateMap<PlaceOfWork, PlaceOfWorkDTO>()
				.ForMember(
					dest => dest.Technologies, 
					opt => {
						opt.Condition(x => x.Technologies != null);
						opt.MapFrom(x => x.Technologies.Select(x => 
							new TechnologyDTO { Title = x.TechnologyTitle }));
					})
				.ReverseMap()
				.ForMember(
					dest => dest.Technologies,
					opt =>
					{
						opt.Condition(x => x.Technologies != null);
						opt.MapFrom(x => x.Technologies.Select(x =>
							new TechnologyPlaceOfWork { TechnologyTitle = x.Title, Technology = new Technology { Title = x.Title } }));
					}
				);
			CreateMap<PlaceOfWork, CreatePlaceOfWorkRequest>()
				.ForMember(
					dest => dest.Technologies,
					opt => {
						opt.Condition(x => x.Technologies != null);
						opt.MapFrom(x => x.Technologies.Select(x =>
							new TechnologyDTO { Title = x.TechnologyTitle }));
					})
				.ReverseMap()
				.ForMember(
					dest => dest.Technologies,
					opt =>
					{
						opt.Condition(x => x.Technologies != null);
						opt.MapFrom(x => x.Technologies.Select(x =>
							new TechnologyPlaceOfWork { TechnologyTitle = x.Title, Technology = new Technology { Title = x.Title } }));
					}
				);

			CreateMap<Technology, TechnologyDTO>().ReverseMap();
		}
	}
}
