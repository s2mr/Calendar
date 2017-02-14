using System;
namespace Calendar
{
	public class DateManager
	{
		public DateManager()
		{
		}

		public string GetYearStr()
		{
			var date = DateTime.Now;
			return date.Year.ToString();
		}

		public string GetMonthStr()
		{
			var date = DateTime.Now;
			return date.Month.ToString();
		}

		public string GetDayStr()
		{
			var date = DateTime.Now;
			return date.Day.ToString();
		}

		public int GetYearInt()
		{
			var date = DateTime.Now;
			return date.Year;
		}

		public int GetMonthInt()
		{
			var date = DateTime.Now;
			return date.Month;
		}

		public int GetDayInt()
		{
			var date = DateTime.Now;
			return date.Day;
		}

		public string GetDayOfWeekStr()
		{
			var date = DateTime.Now;
			string dayStr = "";
			switch (date.DayOfWeek)
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
