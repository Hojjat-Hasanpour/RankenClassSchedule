using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankenClassSchedule.Models.DomainModels;

namespace RankenClassSchedule.Models.Configurations
{
	public class TeacherConfig : IEntityTypeConfiguration<Teacher>
	{
		public void Configure(EntityTypeBuilder<Teacher> entity)
		{
			entity.HasData(
				new Teacher { TeacherId = 1, FirstName = "Hojjat", LastName = "Hasanpour" },
				new Teacher { TeacherId = 2, FirstName = "Evan", LastName = "Gudmestad" },
				new Teacher { TeacherId = 3, FirstName = "Arthur", LastName = "Morgan" },
				new Teacher { TeacherId = 4, FirstName = "Charles", LastName = "Smith" },
				new Teacher { TeacherId = 5, FirstName = "Hosea", LastName = "Matthews" }
				);
		}
	}
}
