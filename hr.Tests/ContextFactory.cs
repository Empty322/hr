using hr.DB.Models;
using hr.DB;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Matching;
using NSubstitute;

namespace hr.Tests
{
	internal static class ContextFactory
	{
		public static Mock<ApplicationDbContext> Create(
				IQueryable<Candidate>? candidates = null,
				IQueryable<PlaceOfWork>? placesOfWork = null,
				IQueryable<Vacancy>? vacancies = null,
				IQueryable<CandidateStatus>? statuses = null,
				IQueryable<Technology>? technologies = null
			)
		{
			if (candidates == null)
				candidates = new List<Candidate>().AsQueryable();
			if (placesOfWork == null)
				placesOfWork = new List<PlaceOfWork>().AsQueryable();
			if (vacancies == null)
				vacancies = new List<Vacancy>().AsQueryable();
			if (statuses == null)
				statuses = new List<CandidateStatus>().AsQueryable();
			if (technologies == null)
				technologies = new List<Technology>().AsQueryable();
			

			var mockContext = new Mock<ApplicationDbContext>();

			var candidatesSet = CreateDbSet(candidates);
			var placesOfWorkSet = CreateDbSet(placesOfWork);
			var vacanciesSet = CreateDbSet(vacancies);
			var statusesSet = CreateDbSet(statuses);
			var technologiesSet = CreateDbSet(technologies);

			mockContext.Setup(c => c.Candidates).Returns(candidatesSet);
			mockContext.Setup(c => c.PlacesOfWork).Returns(placesOfWorkSet);
			mockContext.Setup(c => c.Vacancies).Returns(vacanciesSet);
			mockContext.Setup(c => c.CandidateStatuses).Returns(statusesSet);
			mockContext.Setup(c => c.Technologies).Returns(technologiesSet);

			return mockContext;
		}

		private static DbSet<T> CreateDbSet<T>(IQueryable<T> data) where T : class
		{
			var mockSet = new Mock<DbSet<T>>();
			mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
			mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

			mockSet.Setup(m => m.Include(It.IsAny<string>())).Returns(mockSet.Object);

			return mockSet.Object;
		}
	}
}
