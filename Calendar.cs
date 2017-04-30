using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar
{
	public class App : Application
	{
		Grid grid;

		Label yearLabel;
		Label dateLabel;
		Label dayOfWeekLabel;
		Label timeLabel;

		Label todayTomorrowLabel;
		Label trashLabel;

		Grid weatherGrid;
		Image weatherImage;
		Label weatherLabel;
		Label weatherDetailLabel;

		Label maxTempLabel;
		Label minTempLabel;

		DateManager dm;
		TrashManager tm;


		public App()
		{
			dm = new DateManager();
			tm = new TrashManager();

			setupWeatherGrid();
			setupContent();

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				string year = dm.GetYearStr() + "年";
				string date = dm.GetMonthStr() + "月" + dm.GetDayStr() + "日";
				string time = dm.GetTimeString();
				string dayOfWeek = dm.GetDayOfWeekStr() + "曜日";
				string kind = tm.GetTrashString();
				string todayTomorrow = tm.GetTodayTomorrowString();
				yearLabel.Text = year;
				dateLabel.Text = date;
				dayOfWeekLabel.Text = dayOfWeek;
				timeLabel.Text = time;
				trashLabel.Text = kind;
				todayTomorrowLabel.Text = todayTomorrow;

				string now = DateTime.Now.ToString("T");
				var am9 = new TimeSpan(9, 0, 0).ToString("g");
				var pm9 = new TimeSpan(21, 0, 0).ToString("g");
				if ((now == am9) || (now == pm9))
				{
					PushNotificationManager.SendPushNotification();
				}

				return true;
			});

			Device.StartTimer(TimeSpan.FromHours(2), () =>
			{
				updateWeather3Hour();
				updateWeatherDaily();
				return true;
			});

			var contentPage = new ContentPage();
			contentPage.BackgroundImage = "bg.jpg";
			contentPage.Content = grid;

			makeAsync();

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

		private void makeAsync()
		{
			updateWeatherDaily();
			updateWeather3Hour();
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

		private async void updateWeatherDaily()
		{
			await ForecastManager.AsyncGetWebAPIDataDaily();
			double maxValue = ForecastManager.getMaxTemperature();
			double minValue = ForecastManager.getMinTemperature();
			string max = string.Format("最高{0}℃", maxValue.ToString("F1"));
			string min = string.Format("最低{0}℃", minValue.ToString("F1"));

			weatherImage.Source = ForecastManager.getWeatherIconName();
			weatherLabel.Text = ForecastManager.getWeather();
			weatherDetailLabel.Text = ForecastManager.getWeatherDetail();
			maxTempLabel.Text = max;
			minTempLabel.Text = min;
			return;
		}

		private async void updateWeather3Hour()
		{
			await ForecastManager.AsyncGetWebAPIData3Hour();

			ForecastManager.getTempArray();

			return;
		}

		private void setupWeatherGrid()
		{
			weatherLabel = new Label
			{
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				BackgroundColor = Color.White,
				Opacity = 0.4,
				FontSize = 50
			};
			weatherDetailLabel = new Label
			{
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				BackgroundColor = Color.White,
				Opacity = 0.4,
				FontSize = 30
			};

			weatherImage = new Image
			{
				BackgroundColor = Color.White,
				Opacity = 0.4
			};

			weatherGrid = new Grid
			{
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Star},
					new RowDefinition { Height = GridLength.Star}
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Star},
					new ColumnDefinition { Width = GridLength.Star}
				}
			};

			weatherGrid.Children.Add(weatherImage, 0, 0);
			weatherGrid.Children.Add(weatherLabel, 1, 0);
			weatherGrid.Children.Add(weatherDetailLabel, 1, 1);
			Grid.SetRowSpan(weatherImage, 2);
		}

		private void setupContent()
		{

			timeLabel = TitleLabel(dm.GetTimeString(), Color.Pink);
			trashLabel = TitleLabel(dm.GetTimeString(), Color.Pink);
			todayTomorrowLabel = TitleLabel("今日は", Color.Olive);
			maxTempLabel = TitleLabel("最高 ???", Color.Maroon);
			maxTempLabel.FontSize = 60;
			minTempLabel = TitleLabel("最低 ???", Color.Teal);
			minTempLabel.FontSize = 60;

			grid = new Grid
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

			yearLabel = TitleLabel(dm.GetYearStr() + "年", Color.Accent);
			dateLabel = TitleLabel(dm.GetMonthStr() + "月" + dm.GetDayStr() + "日", Color.Blue);
			dayOfWeekLabel = TitleLabel(dm.GetDayOfWeekStr() + "曜日", Color.White);

			//１列目にラベルを追加
			grid.Children.Add(yearLabel, 0, 0);//0行0列
			grid.Children.Add(dateLabel, 0, 1);//0行1列
			grid.Children.Add(dayOfWeekLabel, 0, 2);//0行1列
			grid.Children.Add(timeLabel, 0, 3);//0行1列

			grid.Children.Add(todayTomorrowLabel, 1, 0); //２列目で左から１~２カラム
			grid.Children.Add(trashLabel, 1, 1);//２列目で左から３カラム目
			grid.Children.Add(TitleLabel("天気", Color.Orange), 1, 2);//0行1列
			grid.Children.Add(maxTempLabel, 2, 2);//0行1列
			grid.Children.Add(weatherGrid, 1, 3);//0行1列
			grid.Children.Add(minTempLabel, 2, 3);//0行1列

			Grid.SetColumnSpan(todayTomorrowLabel, 2);
			Grid.SetColumnSpan(trashLabel, 2);
		}
	}
}
