using System.ComponentModel.DataAnnotations;

namespace hr.Models.Technology
{
	public class TechnologyDTO
	{
		[Required]
		public string Title { get; set; } = string.Empty;
	}
}
