using AutoMapper;
using hr.DB.Models;
using hr.Models.Candidate;
using hr.Models.CandidateStatus;
using hr.Models.PlaceOfWork;
using hr.Models.Technology;
using hr.Models.Vacancy;

namespace hr.AutoMapper
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			#region Candidate Maps

			CreateMap<Candidate, CandidateDTO>().ReverseMap();
			CreateMap<Candidate, CreateCandidateRequest>().ReverseMap();

			#endregion

			#region PlaceOfWork Maps

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

			CreateMap<PlaceOfWork, UpdatePlaceOfWorkRequest>()
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

			CreateMap<PlaceOfWorkDTO, UpdatePlaceOfWorkRequest>().ReverseMap();

			#endregion

			#region Vacancy Maps

			CreateMap<Vacancy, VacancyDTO>()
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
							new TechnologyVacancy { TechnologyTitle = x.Title, Technology = new Technology { Title = x.Title } }));
					}
				);
			CreateMap<Vacancy, CreateVacancyRequest>()
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
							new TechnologyVacancy { TechnologyTitle = x.Title, Technology = new Technology { Title = x.Title } }));
					}
				);

			#endregion

			#region CandidateStatus Maps

			CreateMap<CandidateStatus, CandidateStatusDTO>().ReverseMap();
			CreateMap<CandidateStatus, CreateCandidateStatusRequest>().ReverseMap();
			CreateMap<CandidateStatus, UpdateCandidateStatusRequest>().ReverseMap();

			#endregion

			#region Technology Maps

			CreateMap<Technology, TechnologyDTO>().ReverseMap();

			#endregion
		}
	}
}
