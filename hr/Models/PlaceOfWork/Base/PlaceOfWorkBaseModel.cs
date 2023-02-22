using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Dispatcher;

namespace hr.Models.PlaceOfWork.Base
{
	public class PlaceOfWorkBaseModel : IValidatableObject
	{
		[Required]
		public DateTime? Begin { get; set; }
		[Required]
		public DateTime? End { get; set; }
		[Required]
		public string Company { get; set; } = string.Empty;
		[Required]
		public string Position { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (Begin > End)
				yield return new ValidationResult("Begin date must be before End date", new List<string> { nameof(Begin), nameof(End) });
		}
	}
}
