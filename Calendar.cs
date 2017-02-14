using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar
{
	public class App : Application
	{
		Label maxTempLabel;
		Label minTempLabel;
		Label timeLabel;
		Label yearLabel;
		Label dateLabel;
		Label dayOfWeekLabel;
		Label trashLabel;

		ForecastManager fm;

		public App()
		{
			var dm = new DateManager(DateTime.Now);
			var tm = new TrashManager(DateTime.Now);

			timeLabel = TitleLabel(dm.GetTimeString(), Color.Pink);
			trashLabel = new Label
			{
				FontSize = 70,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				BackgroundColor = Color.White,
				Opacity = 0.4
			};
			//var timeLabel = new Label();


			Device.StartTimer(new TimeSpan(10000 * 500), () =>
			{
			string trash = tm.GetLabelKindOfTrash();
				string year = dm.GetYearStr() + "年";
				string date = dm.GetMonthStr() + "月" + dm.GetDayStr() + "日";
				string time = dm.GetTimeString();
				string dayOfWeek = dm.GetDayOfWeekStr() + "曜日";
				yearLabel.Text = year;
				dateLabel.Text = date;
				dayOfWeekLabel.Text = dayOfWeek;
				timeLabel.Text = time;
				trashLabel.Text = trash;
				return true;
			});

			var grid = new Grid
			{
				Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 10),//パディング
				RowSpacing = 5, //縦のスペース
				ColumnSpacing = 5, //横のスペース
				RowDefinitions = {//縦に4行
                new RowDefinition { Height = GridLength.Star },//（高さ）自動調整
                new RowDefinition { Height = GridLength.Star },
				new RowDefinition { Height = GridLength.Star },
				new RowDefinition { Height = GridLength.Star }
				},
				ColumnDefinitions = {//横に３カラム
                new ColumnDefinition { Width = GridLength.Star }, //(幅)自動調整
                new ColumnDefinition { Width = GridLength.Star },
				new ColumnDefinition { Width = GridLength.Star }
				}
			};

			var label1 = TitleLabel("今日は", Color.Olive);
			//trashLabel = tm.GetLabelKindOfTrash();

			maxTempLabel = TitleLabel("最高 ???", Color.Maroon);
			minTempLabel = TitleLabel("最低 ???", Color.Teal);

			yearLabel = TitleLabel(dm.GetYearStr() + "年", Color.Accent);
			dateLabel = TitleLabel(dm.GetMonthStr() + "月" + dm.GetDayStr() + "日", Color.Blue);
			dayOfWeekLabel = TitleLabel(dm.GetDayOfWeekStr() + "曜日", Color.White);

			//１列目にラベルを追加
			grid.Children.Add(yearLabel, 0, 0);//0行0列
			grid.Children.Add(dateLabel, 0, 1);//0行1列
			grid.Children.Add(dayOfWeekLabel, 0, 2);//0行1列

			var cvm = new ClockViewModel();

			//var timeLabel2 = new Label();
			//timeLabel2.BindingContext = cvm;
			//timeLabel2.SetBinding(Label.TextProperty, "Time");


			timeLabel.BindingContext = new ClockViewModel();
			timeLabel.SetBinding(Label.TextProperty, "{Binding MyDateTime, StringFormat='{0:T}'}");


			grid.Children.Add(timeLabel, 0, 3);//0行1列

			grid.Children.Add(label1, 1, 0); //２列目で左から１~２カラム
			grid.Children.Add(trashLabel, 1, 1);//２列目で左から３カラム目
			grid.Children.Add(TitleLabel("降水確率", Color.Orange), 1, 2);//0行1列
			grid.Children.Add(maxTempLabel, 2, 2);//0行1列
			grid.Children.Add(TitleLabel("７０%", Color.Lime), 1, 3);//0行1列
			grid.Children.Add(minTempLabel, 2, 3);//0行1列

			Grid.SetColumnSpan(label1, 2);
			Grid.SetColumnSpan(trashLabel, 2);


			var contentPage = new ContentPage();
			contentPage.BackgroundImage = "bg.jpg";
			contentPage.Content = grid;

			getWeather();

			MainPage = contentPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
		}

		private async Task makeAsync()
		{
			await getWeather();
		}

		protected Label TitleLabel(String title, Color color)
		{
			var label = new Label();

			label.Text = title;

			label.BackgroundColor = Color.White;
			label.Opacity = 0.4;
			label.FontSize = 70;
			label.HorizontalTextAlignment = TextAlignment.Center;
			label.VerticalTextAlignment = TextAlignment.Center;

			return label;
		}

		private async Task getWeather()
		{
			fm = new ForecastManager();
			await fm.AsyncGetWebAPIData();

			string max = string.Format("最高{0}℃", fm.getMaxTemperature());
			//string min = string.Format("最高{0}℃", fm.getMinTemperature());

			maxTempLabel.Text = max;
			//minTempLabel.Text = min;
		}
	}
}
