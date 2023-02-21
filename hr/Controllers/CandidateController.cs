using hr.Models.Candidate;
using hr.Models.Technology;
using hr.Services;
using hr.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers
{
	[ApiController]
	[Route("candidates")]
	public class CandidateController : ControllerBase
	{
		private readonly ICandidateService candidateService;

		public CandidateController(ICandidateService candidateService)
		{
			this.candidateService = candidateService;
		}

		[HttpPost]
		public ActionResult<CandidateDTO> Create([FromBody] CreateCandidateRequest candidate)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var createdCandidate = candidateService.Create(candidate);

			return Ok(createdCandidate);
		}

		[HttpGet("{id}")]
		public ActionResult<CandidateDTO> Get(int id)
		{
			var candidate = candidateService.Get(id);

			if (candidate == null)
				return NotFound();

			return Ok(candidate);
		}

		[HttpGet("suitable")]
		public ActionResult<IEnumerable<CandidateDTO>> GetSuitableCandidates([FromBody] IEnumerable<TechnologyDTO> technologies)
		{
			var candidates = candidateService.GetSuitable(technologies);
			return Ok(candidates);
		}

		[HttpPut]
		public ActionResult Update([FromBody] CandidateDTO candidate)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var updatedCandidate = candidateService.Update(candidate);
			if (updatedCandidate == null)
				return NotFound();

			return Ok();
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var deletedCandidate = candidateService.Delete(id);

			if (deletedCandidate == null)
				return NotFound();

			return Ok();
		}
	}
}