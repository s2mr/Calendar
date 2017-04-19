using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Calendar
{
	public class TrashManager
	{
		public TrashManager()
		{
		}

		public String GetTrashString()
		{

			var date = DateTime.Now;
			string kind = "";
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Monday:
					kind = "金属ごみ";
					break;
				case DayOfWeek.Tuesday:
					kind = "普通ごみ";
					break;
				case DayOfWeek.Friday:
					kind = "普通ごみ";
					break;
				case DayOfWeek.Sunday:
					kind = "休み";
					break;
				case DayOfWeek.Saturday:
					kind = "休み";
					break;
				default:
					if (Glass.isGlass(date.Month, date.Day))
					{
						kind = "ガラス";
					}
					else if (Pet.isPet(date.Month, date.Day))
					{
						kind = "ペットボトル";
					}
					else if (Paper.isPaper(date.Month, date.Day))
					{
						kind = "新聞・布（衣類）";
					}else if (Middle.isMiddle(date.Month, date.Day))
					{
						kind = "中型ごみ";
					}
					break;
			}

			if (date.Month == 5 && date.Day == 3
			   || date.Month == 7 && date.Day == 17
			   || date.Month == 9 && date.Day == 18
			   || date.Month == 10 && date.Day == 9
			   || date.Month == 1 && date.Day == 1
			   || date.Month == 1 && date.Day == 2
			   || date.Month == 1 && date.Day == 3
			   || date.Month == 2 && date.Day == 12
			   || date.Month == 3 && date.Day == 21)
				kind = "休み";

			return kind + "の日";

			//var label = new Label();
			//label.Text = kind + "の日";

			//label.BackgroundColor = Color.White;
			//label.Opacity = 0.4;
			//label.FontSize = 70;
			//label.HorizontalTextAlignment = TextAlignment.Center;
			//label.VerticalTextAlignment = TextAlignment.Center;
			//return label;
		}
	}

	class Glass
	{
		static Date[] date = new Date[]
			{
					new Date {
						_month = 4,
						_day = new[] {5, 19}
					},
					new Date {
						_month = 5,
						_day = new[] {17, 31}
					},
					new Date {
						_month = 6,
						_day = new[] {14, 28}
					},
					new Date {
						_month = 7,
						_day = new[] {12, 26}
					},
					new Date {
						_month = 8,
						_day = new[] {9, 23}
					},
					new Date {
						_month = 9,
						_day = new[] {6, 20}
					},
					new Date {
						_month = 10,
						_day = new[] {4, 18}
					},
					new Date {
						_month = 11,
						_day = new[] {1, 15, 29}
					},
					new Date {
						_month = 12,
						_day = new[] {13, 27}
					},
					new Date {
						_month = 1,
						_day = new[] {10, 24}
					},
					new Date {
						_month = 2,
						_day = new[] {18, 7}
					},
					new Date {
						_month = 3,
						_day = new[] {7}
					},

			};
		struct Date
		{
			public int _month;
			public int[] _day;
		}

		public static bool isGlass(int month, int day)
		{
			foreach (var item in date)
			{
				if (month == item._month)
				{
					foreach (var d in item._day)
					{
						if (d == day)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}

	class Pet
	{
		static Date[] date = new Date[]
			{
					new Date {
						_month = 4,
						_day = new[] {12, 26}
					},
					new Date {
						_month = 5,
						_day = new[] {10, 24}
					},
					new Date {
						_month = 6,
						_day = new[] {7, 21}
					},
					new Date {
						_month = 7,
						_day = new[] {5, 19}
					},
					new Date {
						_month = 8,
						_day = new[] {2,16,30}
					},
					new Date {
						_month = 9,
						_day = new[] {13,27}
					},
					new Date {
						_month = 10,
						_day = new[] {11,25}
					},
					new Date {
						_month = 11,
						_day = new[] {8,22}
					},
					new Date {
						_month = 12,
						_day = new[] {6,20}
					},
					new Date {
						_month = 1,
						_day = new[] {17,31}
					},
					new Date {
						_month = 2,
						_day = new[] {14,28}
					},
					new Date {
						_month = 3,
						_day = new[] {14,28}
					},

			};
		struct Date
		{
			public int _month;
			public int[] _day;
		}

		public static bool isPet(int month, int day)
		{
			foreach (var item in date)
			{
				if (month == item._month)
				{
					foreach (var d in item._day)
					{
						if (d == day)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}

	class Paper
	{
		static Date[] date = new Date[]
			{
					new Date {
						_month = 4,
						_day = new[] {6, 20}
					},
					new Date {
						_month = 5,
						_day = new[] {4, 18}
					},
					new Date {
						_month = 6,
						_day = new[] {1,15,29}
					},
					new Date {
						_month = 7,
						_day = new[] {13, 27}
					},
					new Date {
						_month = 8,
						_day = new[] {10, 24}
					},
					new Date {
						_month = 9,
						_day = new[] {7, 21}
					},
					new Date {
						_month = 10,
						_day = new[] {5, 19}
					},
					new Date {
						_month = 11,
						_day = new[] {2, 16, 30}
					},
					new Date {
						_month = 12,
						_day = new[] {14, 28}
					},
					new Date {
						_month = 1,
						_day = new[] {11, 25}
					},
					new Date {
						_month = 2,
						_day = new[] {8,22}
					},
					new Date {
						_month = 3,
						_day = new[] {8,22}
					},

			};
		struct Date
		{
			public int _month;
			public int[] _day;
		}

		public static bool isPaper(int month, int day)
		{
			foreach (var item in date)
			{
				if (month == item._month)
				{
					foreach (var d in item._day)
					{
						if (d == day)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}

	class Middle
	{
		static Date[] date = new Date[]
			{
					new Date {
						_month = 4,
						_day = new[] {13, 27}
					},
					new Date {
						_month = 5,
						_day = new[] {11, 25}
					},
					new Date {
						_month = 6,
						_day = new[] {8, 22}
					},
					new Date {
						_month = 7,
						_day = new[] {6, 20}
					},
					new Date {
						_month = 8,
						_day = new[] {3, 17,31}
					},
					new Date {
						_month = 9,
						_day = new[] {14,28}
					},
					new Date {
						_month = 10,
						_day = new[] {12, 26}
					},
					new Date {
						_month = 11,
						_day = new[] {9, 23}
					},
					new Date {
						_month = 12,
						_day = new[] {7, 21}
					},
					new Date {
						_month = 1,
						_day = new[] {4, 18}
					},
					new Date {
						_month = 2,
						_day = new[] {1, 15}
					},
					new Date {
						_month = 3,
						_day = new[] {1,15,29}
					},

			};
		struct Date
		{
			public int _month;
			public int[] _day;
		}

		public static bool isMiddle(int month, int day)
		{
			foreach (var item in date)
			{
				if (month == item._month)
				{
					foreach (var d in item._day)
					{
						if (d == day)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
