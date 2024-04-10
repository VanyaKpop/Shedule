using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Views;
using System.Globalization;
using System;
using lesson;
namespace Hiii_uwu
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static int week = (int)ISOWeek.GetWeekOfYear(DateTime.Now) - 1;
        public void NextWeekButton()
        {
            week++;
            setText(); 
        }
        public void WeekNowButton()
        {
            week = (int)ISOWeek.GetWeekOfYear(DateTime.Now) - 1;
            setText();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
 
            SetContentView(Resource.Layout.activity_main);

            setText();

            Button WeekNow = (Button)FindViewById(Resource.Id.Main_WeekNowButton);
            WeekNow.Click += (sender, e) =>
            {
                WeekNowButton();
            };

            Button NextWeek = (Button)FindViewById(Resource.Id.Main_NextWeekButton);
            NextWeek.Click += (sender, e) =>
            {
               NextWeekButton();
            };

        }
		void setText()
		{
            Lessons lessons = new Lessons();

            TextView WeekNow = (TextView)FindViewById(Resource.Id.Main_WeekNow);
            WeekNow.Text = $" {week} неделя";

            TextView mondayText = (TextView)FindViewById(Resource.Id.MainTextMonday);
            TextView tuesdayText = (TextView)FindViewById(Resource.Id.MainTextTuesday);
            TextView wednesdayText = (TextView)FindViewById(Resource.Id.MainTextWednesday);
            TextView thursdayText = (TextView)FindViewById(Resource.Id.MainTextThursday);
            TextView fridayText = (TextView)FindViewById(Resource.Id.MainTextFriday);
            TextView saturdayText = (TextView)FindViewById(Resource.Id.MainTextSaturday);

            mondayText.Text = lessons.jsonLoad("monday", week);
            tuesdayText.Text = lessons.jsonLoad("tuesday", week);
            wednesdayText.Text = lessons.jsonLoad("wednesday", week);
            thursdayText.Text = lessons.jsonLoad("thursday", week);
            fridayText.Text = lessons.jsonLoad("friday", week);
            saturdayText.Text = lessons.jsonLoad("saturday", week);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}