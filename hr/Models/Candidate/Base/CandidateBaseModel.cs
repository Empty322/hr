using System.ComponentModel.DataAnnotations;

namespace hr.Models.Candidate.Base
{
	public class CandidateBaseModel: IValidatableObject
	{
		[Required]
		public DateTime? DateOfBirth { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (DateOfBirth > DateTime.Now)
				yield return new ValidationResult("Date of birth must be past", new List<string> { nameof(DateOfBirth) });
		}
	}
}
