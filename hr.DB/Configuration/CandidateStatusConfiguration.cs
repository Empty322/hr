using hr.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hr.DB.Configuration;

internal class CandidateStatusConfiguration : IEntityTypeConfiguration<CandidateStatus>
{
	public void Configure(EntityTypeBuilder<CandidateStatus> builder)
	{
		builder.HasData(
			new CandidateStatus
			{
				Id = 1,
				CandidateId = 1,
				VacancyId = 1,
				Status = Enums.Status.New
			},
			new CandidateStatus
			{
				Id = 2,
				CandidateId = 1,
				VacancyId = 2,
				Status = Enums.Status.Rejection
			},
			new CandidateStatus
			{
				Id = 3,
				CandidateId = 2,
				VacancyId = 1,
				Status = Enums.Status.TechInterview
			},
			new CandidateStatus
			{
				Id = 4,
				CandidateId = 2,
				VacancyId = 3,
				Status = Enums.Status.JobOffer
			},
			new CandidateStatus
			{
				Id = 5,
				CandidateId = 3,
				VacancyId = 3,
				Status = Enums.Status.ManagerInterview
			}
		);
	}
}
