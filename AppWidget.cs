using Android.Support.V4;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Appwidget;
using Android.Widget;
using System.Globalization;
using lesson;
using System;


namespace Hiii_uwu
{
	[BroadcastReceiver(Label = "scheduleApp")]
	[IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE" })]
	[MetaData("android.appwidget.provider", Resource = "@xml/widget_provider")]
	class AppWidget : AppWidgetProvider
	{
        private static string AnnouncementClick = "AnnouncementClickTag";

        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds)
        {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            var meInt = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, appWidgetIds));

        }
        private RemoteViews BuildRemoteViews(Context context, int[] appWidgetIds)
        {
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.Widget);

            var intent = new Intent(context, typeof(AppWidget));
            intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);

            SetTextViewText(widgetView);
            RegisterClicks(context, appWidgetIds, widgetView);

            return widgetView;
        }
        private void SetTextViewText(RemoteViews widgetView)
        {
            Lessons lessons = new Lessons();
            
            widgetView.SetTextViewText(Resource.Id.widgetText, lessons.jsonLoad());
        }
        
        private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView)
        {
            var intent = new Intent(context, typeof(AppWidget));
            intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
            intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);

            // Register click event for the Background
            var piBackground = PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.UpdateCurrent);
            widgetView.SetOnClickPendingIntent(Resource.Id.widgetBackground, GetPendingSelfIntent(context, AnnouncementClick));
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
            if (AnnouncementClick.Equals(intent.Action))
            {
                goToApp();
            }
        }


        public void goToApp()
		{
            PackageManager pm = Android.App.Application.Context.PackageManager;

            var intent = pm.GetLaunchIntentForPackage("scheduleApp.OMGU");

            if (intent != null)
            {

                intent.SetFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }
    }

} 