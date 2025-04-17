using Microsoft.AspNetCore.Mvc;
using RankenClassSchedule.Models.DataLayer;
using RankenClassSchedule.Models.DomainModels;

namespace RankenClassSchedule.Controllers
{
	public class ClassController : Controller
	{
		private Repository<Class> classes { get; set; }
		private Repository<Teacher> teachers { get; set; }
		private Repository<Day> days { get; set; }

		public ClassController(ClassScheduleContext context)
		{
			classes = new Repository<Class>(context);
			teachers = new Repository<Teacher>(context);
			days = new Repository<Day>(context);
		}
		public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

		[HttpGet]
		public ViewResult Add()
		{
			this.LoadViewBag("Add");
			return View("AddEdit", new Class());
		}

		[HttpPost]
		public IActionResult Add(Class classObj)
		{
			bool isAdd = classObj.ClassId == 0;
			if (!ModelState.IsValid)
			{
				string operation = isAdd ? "Add" : "Edit";
				this.LoadViewBag(operation);
				return View("AddEdit", classObj);
			}
			
			if (isAdd)
				classes.Insert(classObj);
			else
				classes.Update(classObj);
			classes.Save();
			return RedirectToAction("Index","Home");
		}

		[HttpGet]
		public ViewResult Edit(int id)
		{
			var classObj = GetClass(id);
			this.LoadViewBag("Edit");
			return View("AddEdit", classObj);
		}

		[HttpGet]
		public ViewResult Delete(int id)
		{
			var classObj = GetClass(id);
			return View(classObj);
		}

		[HttpPost]
		public RedirectToActionResult Delete(Class classObj)
		{
			classes.Delete(classObj);
			classes.Save();
			return RedirectToAction("Index", classObj);
		}

		private Class GetClass(int id)
		{
			var options = new QueryOptions<Class>
			{
				Where = c => c.ClassId == id,
				Includes = "Teacher, Day"
			};
			return classes.Get(options) ?? new Class();
		}

		private void LoadViewBag(string operation)
		{
			ViewBag.Days = days.List(new QueryOptions<Day>
			{
				OrderBy = d => d.DayId
			});

			ViewBag.Teachers = teachers.List(new QueryOptions<Teacher>
			{
				OrderBy = t => t.LastName
			});
			ViewBag.Operation = operation;
		}
	}
}
