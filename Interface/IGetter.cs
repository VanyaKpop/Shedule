using Shedule.Model;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Globalization;

namespace Shedule.Interface
{
	public interface IGetterService
	{
		Task<string> GetLesson( string DayOfTheWeek);

		int GetWeek(int week);
		void SetWeek(int week);
	}

	public class GetterService : IGetterService
	{
		private HttpClient httpClient = new HttpClient();

		private int Week { get; set; }

		public void SetWeek(int week)
		{
			Week = week;
		}

		public int GetWeek(int week)
		{
			return Week;
		}
		public async Task<string> GetLesson(string DayOfTheWeek)
		{
			LessonModel resulteParse = await httpClient.GetFromJsonAsync<LessonModel>("https://raw.githubusercontent.com/VanyaKpop/JsonFiles/main/Lessons_Din_219.json");

			var result =
				from i in resulteParse.Lesson
				where i.weekStart <= Week && Week <= i.weekEnd && i.idWeek == DayOfTheWeek && (i.even == null || i.even == (Week % 2 == 0))
				orderby i.numeration
				select i;

			string lesson = ""; 

			foreach (var item in result)
			{
				lesson += $"{item.numeration}) {item.lesson} - {item.time} \n";
			}

			return lesson;
		}
	}
}
