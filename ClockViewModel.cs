using System;
using System.ComponentModel;
using Xamarin.Forms;
namespace Calendar
{
	class ClockViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		DateTime myDateTime;

		public ClockViewModel()
		{
			this.MyDateTime = DateTime.Now;
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{

				MyDateTime = DateTime.Now;
				return true;
			});
		}

		public DateTime MyDateTime
		{
			set
			{
				if (myDateTime != value)
				{
					myDateTime = value;
					PropertyChanged(this, new PropertyChangedEventArgs("MyDateTime"));
				}
			}
			get { return myDateTime; }
		}

	}
}
