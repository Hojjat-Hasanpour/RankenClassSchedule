using System.ComponentModel.DataAnnotations;

namespace RankenClassSchedule.Models.DomainModels
{
	public class Teacher
	{
		public Teacher() => Classes = new HashSet<Class>();

		public int TeacherId { get; set; } // Primary Key

		[Display(Name = "First Name")]
		[StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
		[Required(ErrorMessage = "Please enter a first name.")]
		public string FirstName { get; set; } = string.Empty;

		[Display(Name = "Last Name")]
		[StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
		[Required(ErrorMessage = "Please enter a Last name.")]
		public string LastName { get; set; } = string.Empty;


		//Read-only display property
		public string FullName => $"{FirstName} {LastName}";
		//Navigation Properties
		public virtual ICollection<Class> Classes { get; set; }
	}
}
