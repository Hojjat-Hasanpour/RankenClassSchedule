using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankenClassSchedule.Models.DomainModels;

namespace RankenClassSchedule.Models.Configurations
{
	public class ClassConfig : IEntityTypeConfiguration<Class>
	{

		public void Configure(EntityTypeBuilder<Class> entity)
		{
			// Fluent API to change the delete behavior to restrict
			entity.HasOne(c => c.Teacher)
				.WithMany(t => t.Classes)
				.OnDelete(DeleteBehavior.Restrict);
			entity.HasData(
				new Class { ClassId = 1, Title = "Intro to C#", Number = 100, MilitaryTime = "0800", TeacherId = 1, DayId = 1 },
				new Class { ClassId = 2, Title = "Intro to Web Dev", Number = 101, MilitaryTime = "1000", TeacherId = 1, DayId = 2 },
				new Class { ClassId = 3, Title = "Intro to Python", Number = 200, MilitaryTime = "1000", TeacherId = 1, DayId = 1 },
				new Class { ClassId = 4, Title = "JavaScript Intermediat", Number = 300, MilitaryTime = "0800", TeacherId = 3, DayId = 1 },
				new Class { ClassId = 5, Title = "JavaScript Advanced", Number = 300, MilitaryTime = "1000", TeacherId = 3, DayId = 1 },
				new Class { ClassId = 6, Title = "Django Framework", Number = 400, MilitaryTime = "1200", TeacherId = 1, DayId = 4 },
				new Class { ClassId = 7, Title = "Learn Database", Number = 501, MilitaryTime = "1400", TeacherId = 4, DayId = 4 },
				new Class { ClassId = 8, Title = "Python Advanced", Number = 502, MilitaryTime = "1400", TeacherId = 1, DayId = 4 },
				new Class { ClassId = 9, Title = "HTML CSS", Number = 402, MilitaryTime = "1200", TeacherId = 2, DayId = 1 },
				new Class { ClassId = 10, Title = "ASP.NET Core", Number = 502, MilitaryTime = "1400", TeacherId = 2, DayId = 3 },
				new Class { ClassId = 11, Title = "Desktop Support", Number = 202, MilitaryTime = "1600", TeacherId = 5, DayId = 5 },
				new Class { ClassId = 12, Title = "Entity Framework", Number = 301, MilitaryTime = "1400", TeacherId = 5, DayId = 4 },
				new Class { ClassId = 13, Title = "NodeJs", Number = 301, MilitaryTime = "1600", TeacherId = 5, DayId = 4 },
				new Class { ClassId = 14, Title = "Java Language", Number = 201, MilitaryTime = "1000", TeacherId = 4, DayId = 1 }
				);
		}
	}
}
