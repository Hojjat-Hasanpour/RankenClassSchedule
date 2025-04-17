using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RankenClassSchedule.Models.DomainModels
{
	public class Day
	{
		public Day() => Classes = new HashSet<Class>();

		public int DayId { get; set; } //Primary Key

		[Required()]
		[StringLength(10)]
		public string Name { get; set; } = string.Empty;


		//Navigation Property
		public virtual ICollection<Class> Classes { get; set; }
	}
}
