namespace RankenClassSchedule.Models.DataLayer
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> List(QueryOptions<T> options);

		T? Get(int id); //Get Type By Id
		T? Get(QueryOptions<T> options); //Get Type With LINQ Query
		void Insert(T entity); //Create
		void Update(T entity); //Update
		void Delete(T entity); //Delete
		void Save(); //Save Changes
	}
}
