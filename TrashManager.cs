using System;
using Xamarin.Forms;

namespace Calendar
{
	public class TrashManager
	{
		DateTime date;
		public TrashManager(DateTime date)
		{
			this.date = date;
		}

		public string GetLabelKindOfTrash()
		{
			string kind = "";

			switch (date.DayOfWeek)
			{
				case DayOfWeek.Monday:
					kind = "金属ごみ";
					break;
				case DayOfWeek.Tuesday:
					kind = "普通ごみ";
					break;
				case DayOfWeek.Wednesday:
					if (date.Day == 8 || date.Day == 22)
					{
						kind = "ガラス";
					}
					else
					{
						kind = "ペットボトル";
					}
					break;
				case DayOfWeek.Thursday:
					if (date.Day == 9 || date.Day == 23)
					{
						kind = "新聞・布（衣類）";
					}
					else
					{
						kind = "中型ごみ";
					}
					break;
				case DayOfWeek.Friday:
					kind = "普通ごみ";
					break;
				case DayOfWeek.Sunday:
					kind = "";
					break;
				case DayOfWeek.Saturday:
					kind = "";
					break;
				default:
					break;
			}

			if (date.Month == 3 || date.Day == 20)
				kind = "休み";

			var label = new Label();
			label.Text = kind + "の日";

			label.BackgroundColor = Color.White;
			label.Opacity = 0.4;
			label.FontSize = 70;
			label.HorizontalTextAlignment = TextAlignment.Center;
			label.VerticalTextAlignment = TextAlignment.Center;
			return kind + "の日";
		}
	}


}
