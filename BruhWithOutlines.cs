using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Appwidget;
using Android.Widget;
using lesson;
using System;

/*
namespace Hiii_uwu
{
	[BroadcastReceiver(Label = "bruh_without_outlines")]
	[IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
	[MetaData("android.appwidget.provider", Resource = "@xml/widget_provider")]

	class BruhWithOutlines : AppWidgetProvider
    {
        private static string BackgroundClick = "BackgroundClickTag";
        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(BruhWithOutlines)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, appWidgetIds));
        }
        private RemoteViews BuildRemoteViews(Context context, int[] appWidgetIds)
        {
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.Widget);


            SetTextViewText(widgetView);

            return widgetView;
        }
        private void SetTextViewText(RemoteViews widgetView)
        {
            Lessons lessons = new Lessons();
            lessons.jsonLoad(DateTime.Now.DayOfWeek.ToString());

            widgetView.SetTextViewText(Resource.Id.widgetText, lessons.hell);
        }

        private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
        {
            widgetView.SetOnClickPendingIntent(Resource.Id.widgetBackgroundOut,
            GetPendingSelfIntent(context, BackgroundClick));
        }
        private PendingIntent GetPendingSelfIntent(Context context, string action)
        {
            var intent = new Intent(context, typeof(AppWidget));
            intent.SetAction(action);
            return PendingIntent.GetBroadcast(context, 0, intent, 0);
        }


        public override void OnReceive(Context context, Intent intent)
        {
            base.OnReceive(context, intent);

            // Check if the click is from the "Announcement" button
            if (BackgroundClick.Equals(intent.Action))
            {
                goToApp();
            }
        }


        public void goToApp()
        {
            PackageManager pm = Android.App.Application.Context.PackageManager;

            var intent = pm.GetLaunchIntentForPackage("scheduleApp.hiii_uwu");

            if (intent != null)
            {

                intent.SetFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }
    }
} */