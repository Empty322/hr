﻿using hr.DB.Enums;
using hr.Models.Candidate.Base;
using System.ComponentModel.DataAnnotations;

namespace hr.Models.Candidate;

public class CandidateDTO : CandidateBaseModel
{
	[Required]
	public int Id { get; set; }
	[Required]
	public string FullName { get; set; } = string.Empty;
	[Required]
	public Education? Education { get; set; }
	[Required]
	public string University { get; set; } = string.Empty;
	[Required]
	public string Faculty { get; set; } = string.Empty;
}
