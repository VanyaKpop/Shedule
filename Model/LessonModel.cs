namespace Shedule.Model
{
	public class Lesson
	{
		public string idWeek { get; set; }
		public int weekStart { get; set; }
		public int weekEnd { get; set; }
		public int? numeration { get; set; }
		public bool? even { get; set; }
		public string? lesson { get; set; }
		public string? time { get; set; }
	}
	public class LessonModel
	{
		public List<Lesson> Lesson { get; set; }
	}
}
