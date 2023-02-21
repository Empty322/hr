using hr.Models.Vacancy;
using hr.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers
{
	[ApiController]
	[Route("vacancies")]
	public class VacancyController : ControllerBase
	{
		private readonly IVacancyService vacancyService;

		public VacancyController(IVacancyService vacancyService)
		{
			this.vacancyService = vacancyService;
		}

		[HttpPost]
		public ActionResult<VacancyDTO> Create([FromBody] CreateVacancyRequest vacancy)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var createdCandidate = vacancyService.Create(vacancy);

			return Ok(createdCandidate);
		}

		[HttpGet("{id}")]
		public ActionResult<VacancyDTO> Get(int id)
		{
			var vacancy = vacancyService.Get(id);

			if (vacancy == null)
				return NotFound();

			return Ok(vacancy);
		}

		[HttpPut]
		public ActionResult<VacancyDTO> Update([FromBody] VacancyDTO vacancy)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var updatedVacancy = vacancyService.Update(vacancy);
			if (updatedVacancy == null)
				return NotFound();

			return Ok(updatedVacancy);
		}

		[HttpDelete("{id}")]
		public ActionResult<VacancyDTO> Delete(int id)
		{
			var deletedVacancy = vacancyService.Delete(id);

			if (deletedVacancy == null)
				return NotFound();

			return Ok(deletedVacancy);
		}
	}
}