using hr.Models.CandidateStatus;
using hr.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers
{
	[Route("candidate-status")]
	[ApiController]
	public class CandidateStatusController : ControllerBase
	{
		private readonly ICandidateStatusService candidateStatusService;

		public CandidateStatusController(ICandidateStatusService candidateStatusService)
		{
			this.candidateStatusService = candidateStatusService;
		}

		[HttpPost]
		public ActionResult<CandidateStatusDTO> Create([FromBody] CreateCandidateStatusRequest candidateStatus)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var createdCandidate = candidateStatusService.Create(candidateStatus);

			return Ok(createdCandidate);
		}

		[HttpGet("{id}")]
		public ActionResult<CandidateStatusDTO> Get(int id)
		{
			var candidateStatus = candidateStatusService.Get(id);

			if (candidateStatus == null)
				return NotFound();

			return Ok(candidateStatus);
		}

		[HttpPut]
		public ActionResult<CandidateStatusDTO> Update([FromBody] UpdateCandidateStatusRequest candidate)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var updatedCandidateStatus = candidateStatusService.Update(candidate);
			if (updatedCandidateStatus == null)
				return NotFound();

			return Ok(updatedCandidateStatus);
		}

		[HttpDelete("{id}")]
		public ActionResult<CandidateStatusDTO> Delete(int id)
		{
			var deletedCandidateStatus = candidateStatusService.Delete(id);

			if (deletedCandidateStatus == null)
				return NotFound();

			return Ok(deletedCandidateStatus);
		}
	}
}
