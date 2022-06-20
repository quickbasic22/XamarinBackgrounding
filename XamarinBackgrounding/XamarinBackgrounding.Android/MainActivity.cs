using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using XamarinBackgrounding.Messages;
using Xamarin.Forms;
using XamarinBackgrounding.Droid;
using Android.Content;

namespace XamarinBackgrounding.Droid
{
    [Activity(Label = "XamarinBackgrounding", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

			WireUpLongRunningTask();
			WireUpLongDownloadTask();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		void WireUpLongRunningTask()
		{
			MessagingCenter.Subscribe<StartLongRunningTaskMessage>(this, "StartLongRunningTaskMessage", message => {
				var intent = new Intent(this, typeof(LongRunningTaskService));
				StartService(intent);
			});

			MessagingCenter.Subscribe<StopLongRunningTaskMessage>(this, "StopLongRunningTaskMessage", message => {
				var intent = new Intent(this, typeof(LongRunningTaskService));
				StopService(intent);
			});
		}

		void WireUpLongDownloadTask()
		{
			MessagingCenter.Subscribe<DownloadMessage>(this, "Download", message => {
				var intent = new Intent(this, typeof(DownloaderService));
				intent.PutExtra("url", message.Url);
				StartService(intent);
			});
		}
	}
}