using System;
namespace Calendar
{
	public class DateManager
	{
		int year;
		int month;
		int day;
		DayOfWeek dayOfWeek;
		DateTime date;


		public DateManager(DateTime date)
		{
			this.year = date.Year;
			this.month = date.Month;
			this.day = date.Day;
			this.dayOfWeek = date.DayOfWeek;
			this.date = date;
		}

		public string GetYearStr()
		{
			return year.ToString();
		}

		public string GetMonthStr()
		{
			return month.ToString();
		}

		public string GetDayStr()
		{
			return day.ToString();
		}

		public int GetYearInt()
		{
			return year;
		}

		public int GetMonthInt()
		{
			return month;
		}

		public int GetDayInt()
		{
			return day;
		}

		public string GetDayOfWeekStr()
		{
			string dayStr = "";
			switch (this.dayOfWeek)
			{
				case DayOfWeek.Sunday:
					dayStr = "日";
					break;
				case DayOfWeek.Monday:
					dayStr = "月";
					break;
				case DayOfWeek.Tuesday:
					dayStr = "火";
					break;
				case DayOfWeek.Wednesday:
					dayStr = "水";
					break;
				case DayOfWeek.Thursday:
					dayStr = "木";
					break;
				case DayOfWeek.Friday:
					dayStr = "金";
					break;
				case DayOfWeek.Saturday:
					dayStr = "土";
					break;
				default:
					break;
			}

			return dayStr;
		}

		public string GetTimeString()
		{
			var date = DateTime.Now;
			string sec = date.Second.ToString();

			string hour = date.Hour.ToString();
			string min = date.Minute.ToString();


			return hour + ":" + min + ":" + sec;
		}

	}
}
