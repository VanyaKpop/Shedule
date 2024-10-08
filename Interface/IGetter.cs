using Shedule.Model;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Globalization;
using System.Diagnostics.Metrics;

namespace Shedule.Interface
{
	public interface IGetterService
	{
		string Monday { get; }
		string Tuesday { get; }
		string Wednesday { get; }
		string Thursday { get; }
		string Friday { get; }
		string Saturday { get; }

		int? GetWeek();
		void SetWeek(int? week);
	}

	public class GetterService : IGetterService
	{
		private HttpClient httpClient = new HttpClient();

		private int? Week { get; set; }
		public string Monday { get; private set; }
		public string Tuesday { get; private set; }
		public string Wednesday { get; private set; }
		public string Thursday { get; private set; }
		public string Friday { get; private set; }
		public string Saturday { get; private set; }

		public async void SetWeek(int? week)
		{
			if (week == null)
				Week = 0;
			
			Week = week;

			await Task.Run(() => SetLesson());
		}

		public int? GetWeek()
		{
			if (!Week.HasValue)
				return 1;
			return Week;
		}

		private async Task SetLesson()
		{
			Monday = await GetLesson("monday");
			Tuesday = await GetLesson("tuesday");
			Wednesday = await GetLesson("wednesday");
			Thursday = await GetLesson("thursday");
			Friday = await GetLesson("friday");
			Saturday = await GetLesson("saturday");
		}


		private async Task<string> GetLesson(string DayOfTheWeek)
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
