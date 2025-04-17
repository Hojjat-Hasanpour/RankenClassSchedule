using Microsoft.EntityFrameworkCore;
using RankenClassSchedule.Models.Configurations;
using RankenClassSchedule.Models.DomainModels;

namespace RankenClassSchedule.Models.DataLayer
{
	public class ClassScheduleContext(DbContextOptions<ClassScheduleContext> options) : DbContext(options)
	{
		public DbSet<Day> Days { get; set; } = null!;
		public DbSet<Teacher> Teachers { get; set; } = null!;
		public DbSet<Class> Classes { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Seed our data
			modelBuilder.ApplyConfiguration(new DayConfig());
			modelBuilder.ApplyConfiguration(new TeacherConfig());
			modelBuilder.ApplyConfiguration(new ClassConfig());

			base.OnModelCreating(modelBuilder);
		}
	}
}
