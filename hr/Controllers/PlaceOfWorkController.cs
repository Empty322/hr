using hr.Models.Candidate;
using hr.Models.PlaceOfWork;
using hr.Services;
using hr.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hr.Controllers
{
	[ApiController]
	[Route("places-of-work")]
	public class PlaceOfWorkController : ControllerBase
	{
		private readonly IPlaceOfWorkService placeOfWorkService;

		public PlaceOfWorkController(IPlaceOfWorkService placeOfWorkService)
		{
			this.placeOfWorkService = placeOfWorkService;
		}

		[HttpPost]
		public ActionResult<PlaceOfWorkDTO> Create(CreatePlaceOfWorkRequest placeOfWorkRequest)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var createdPlaceOfWork = placeOfWorkService.Create(placeOfWorkRequest);

			return Ok(createdPlaceOfWork);
		}

		[HttpGet("{id}")]
		public ActionResult<PlaceOfWorkDTO> Get(int id)
		{
			var placeOfWork = placeOfWorkService.Get(id);

			if (placeOfWork == null)
				return NotFound();

			return Ok(placeOfWork);
		}

		[HttpPut]
		public ActionResult Update(PlaceOfWorkDTO placeOfWork)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var updatedPlaceOfWork = placeOfWorkService.Update(placeOfWork);
			if (updatedPlaceOfWork == null)
				return NotFound();

			return Ok();
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var deletedPlaceOfWork = placeOfWorkService.Delete(id);

			if (deletedPlaceOfWork == null)
				return NotFound();

			return Ok();
		}
	}
}