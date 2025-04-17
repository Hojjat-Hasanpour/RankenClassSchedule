using Microsoft.AspNetCore.Mvc;
using RankenClassSchedule.Models.DataLayer;
using RankenClassSchedule.Models.DomainModels;

namespace RankenClassSchedule.Controllers
{
	public class TeacherController : Controller
	{
		private Repository<Teacher> teachers { get; set; }

		public TeacherController(ClassScheduleContext context) => teachers = new Repository<Teacher>(context);

		public ViewResult Index()
		{
			var options = new QueryOptions<Teacher>
			{
				OrderBy = t => t.LastName
			};
			return View(teachers.List(options));
		}

		[HttpGet]
		public ViewResult Add() => View();

		[HttpPost]
		public IActionResult Add(Teacher teacher)
		{
			if(!ModelState.IsValid)
				return View(teacher);
			
			teachers.Insert(teacher);
			teachers.Save();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ViewResult Edit(int teacherId)
		{
			var options = new QueryOptions<Teacher>
			{
				Where = t => t.TeacherId == teacherId
			};
			var teacher = teachers.Get(options);
			return View(teacher);
		}

		[HttpGet]
		public ViewResult Delete(int id) => View(teachers.Get(id));
		
		[HttpPost]
		public RedirectToActionResult Delete(Teacher teacher)
		{
			teachers.Delete(teacher);
			teachers.Save();
			return RedirectToAction("Index");
		}
	}
}
