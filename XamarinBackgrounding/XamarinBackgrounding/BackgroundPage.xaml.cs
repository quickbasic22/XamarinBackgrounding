using System;
using Xamarin.Forms;
using XamarinBackgrounding.Messages;

namespace XamarinBackgrounding
{
	public partial class BackgroundPage : ContentPage
	{
		public BackgroundPage ()
		{
			InitializeComponent ();
		}

		public DateTime SleepDate
		{
			set 
			{ 
				SleepDateLabel.Text = value.ToString ("t");
			}
		}

		public string FirstName
		{
			get
			{
				return FirstNameEntry.Text;
			}
			set
			{
				FirstNameEntry.Text = value;
			}
		}
	}
}