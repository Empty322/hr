using hr.DB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hr.DB.Models
{
	/// <summary>
	/// Рабочий процесс
	/// </summary>
	public class CandidateStatus
	{
		public int Id { get; set; }
		public Status Status { get; set; }

		public int CandidateId { get; set; }
		public Candidate? Candidate { get; set; }

		public int VacancyId { get; set; }
		public Vacancy? Vacancy { get; set; }
	}
}
