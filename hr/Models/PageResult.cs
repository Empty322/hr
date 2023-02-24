namespace hr.Models
{
	public class PageResult<T>
	{
		public IEnumerable<T> Result { get; set; } = new List<T>();
		public int Total { get; set; }
		public int PageIndex { get; set; }
		public int PageItemsCount { get; set; }
	}
}
