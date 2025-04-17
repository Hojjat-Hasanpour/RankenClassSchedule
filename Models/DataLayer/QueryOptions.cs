using System.Linq.Expressions;

namespace RankenClassSchedule.Models.DataLayer
{
	public class QueryOptions<T>
	{
		// public properties for sorting and filtering
		public Expression<Func<T, Object>> OrderBy { get; set; } = null!;
		public Expression<Func<T, Object>> ThenOrderBy { get; set; } = null!;
		public Expression<Func<T, bool>> Where { get; set; } = null!;


		private string[] includes = Array.Empty<string>(); // private string array for include statements

		// Public write-only property for include statements - convert string to array
		public string Includes 
		{
			set => includes = value.Replace(" ", "").Split(',');
		}

		// public method to get the includes array - return the string array or null if empty
		public string[] GetIncludes() => includes;

		// read-only properties
		public bool HasWhere => Where != null;
		public bool HasOrderBy => OrderBy != null;
		public bool HasThenOrderBy => ThenOrderBy != null;
	}
}
