using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using Android.Content.Res;
using Newtonsoft.Json;
using System.Linq;

namespace lesson
{
    class Lessons
    {
        string dayOfWeek = DateTime.Now.DayOfWeek.ToString().ToLower();
        int week = (int)ISOWeek.GetWeekOfYear(DateTime.Now) - 1;

        public string jsonLoad()
        {
            string hell = "";
            AssetManager assets = Android.App.Application.Context.Assets;

            using (StreamReader reader = new StreamReader(assets.Open("Lesson.json")))
            {
                var json = reader.ReadToEnd().ToString();
                Root resultParse = JsonConvert.DeserializeObject<Root>(json);

                var item = resultParse.Lesson;

                var result =
                    from i in item
                    where (i.weekStart <= week & week <= i.weekEnd & i.idWeek == dayOfWeek) & (i.even == null | i.even == (week % 2 == 0))

                    orderby i.numeration
                    select i;

                foreach (var i in result)
                {
                    hell += $"{i.numeration}.  {i.lesson} \n";
                }

                return hell;
            }
        }

        public string jsonLoad(string weekNow, int week)
        {
            string hell = "";
            AssetManager assets = Android.App.Application.Context.Assets;

            using (StreamReader reader = new StreamReader(assets.Open("Lesson.json")))
            {
                var json = reader.ReadToEnd().ToString();
                Root resultParse = JsonConvert.DeserializeObject<Root>(json);

                var item = resultParse.Lesson;

                var result =
                    from i in item
                    where i.weekStart <= week && week <= i.weekEnd && i.idWeek == weekNow && (i.even == null || i.even == (week % 2 == 0))

                    orderby i.numeration
                    select i;

                foreach (var i in result)
                {
                    hell += $"{i.numeration}.  {i.lesson} \n";
                }

                return hell;
            }
        }
    }
    class Lesson
    {
        public string idWeek { get; set; }
        public int weekStart { get; set; }
        public int weekEnd { get; set; }
        public int? numeration { get; set; }
        public bool? even { get; set; }
        public string lesson { get; set; }
    }

    class Root
    {
        public List<Lesson> Lesson { get; set; }
    }

}