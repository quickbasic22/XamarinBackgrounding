using System;
using Xamarin.Forms;
using XamarinBackgrounding.Messages;

namespace XamarinBackgrounding
{
    public partial class DownloadPage : ContentPage
	{
		public DownloadPage ()
		{
			InitializeComponent ();

			downloadButton.Clicked += Download;

			MessagingCenter.Subscribe<DownloadProgressMessage> (this, "DownloadProgressMessage", message => {
				Device.BeginInvokeOnMainThread(() => {
					downloadStatus.Text = message.Percentage.ToString("P2");
				});
			});

			MessagingCenter.Subscribe<DownloadFinishedMessage> (this, "DownloadFinishedMessage", message => {
				Device.BeginInvokeOnMainThread(() =>
					{
						catImage.Source = FileImageSource.FromFile(message.FilePath);
					});
			});

		}

		void Download (object sender, EventArgs e)
		{
			catImage.Source = null;
			var message = new DownloadMessage {
				Url = "https://www.wikihow.com/images/thumb/e/e9/Download-Photos-from-Your-iPhone-to-a-Computer-Step-1-Version-4.jpg/aid2597616-v4-728px-Download-Photos-from-Your-iPhone-to-a-Computer-Step-1-Version-4.jpg"
			};

			MessagingCenter.Send (message, "Download");
		}
	}
}