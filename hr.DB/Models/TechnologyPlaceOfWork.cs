using System.ComponentModel.DataAnnotations;

namespace hr.DB.Models;

/// <summary>
/// Технология
/// </summary>
public class TechnologyPlaceOfWork
{
	public string TechnologyTitle { get; set; } = string.Empty;
	public Technology? Technology { get; set; }
	public int PlaceOfWorkId { get; set; }
	public PlaceOfWork? PlaceOfWork { get; set; }
}
