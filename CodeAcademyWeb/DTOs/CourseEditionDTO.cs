using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.DTOs
{
	public class CourseEditionDTO
	{
		public long Id { get; set; }
		public string Code { get; set; }
		public long CourseId { get; set; }
		public string CourseTitle { get; set; }
		public string StartDate { get; set; }
		public decimal RealPrice { get; set; }
	}
}
