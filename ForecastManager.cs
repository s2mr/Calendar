using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Calendar
{
	public class ForecastManager
	{

		Item item;

		string weather { get; set; }

		public double minTemperature
		{
			get
			{
				var dict = item.list[2]["main"] as Dictionary<String, String>;
				string str = dict["temp_min"];
				double doubleVal = Convert.ToDouble(str);

				return doubleVal - 273.15;
			}
		}

		public double maxTemperature
		{
			get
			{
				var dict = item.list[2]["main"] as Dictionary<String, String>;
				string str = dict["temp_max"];
				double doubleVal = Convert.ToDouble(str);

				return doubleVal - 273.15;
			}
		}

		public ForecastManager()
		{
		}

		public double getMinTemperature()
		{
			var dict = item.list[2]["main"] as Dictionary<String, String>;
			string str = dict["temp_min"];
			double doubleVal = Convert.ToDouble(str);

			return doubleVal - 273.15;
		}

		public double getMaxTemperature()
		{
			var dict = item.list[2]["main"];
			var dict2 = dict as IDictionary<String, String>;
			string str = dict2["temp_max"];
			double doubleVal = Convert.ToDouble(str);

			return doubleVal - 273.15;
		}

		// データを取得するメソッド
		public async Task AsyncGetWebAPIData()
		{
			string apiKey = "8d1d292024c6d285eeb507da0ffd0ef9";

			//string AED_URL = "http://weather.livedoor.com/forecast/webservice/json/v1?city=030010";

			string weatherUrl = "http://api.openweathermap.org/data/2.5/forecast/city?id=2110657&APPID=8d1d292024c6d285eeb507da0ffd0ef9";
			// HttpClientの作成 
			HttpClient httpClient = new HttpClient();
			// 非同期でAPIからデータを取得
			Task<string> stringAsync = httpClient.GetStringAsync(weatherUrl);
			string result = await stringAsync;
			// JSON形式のデータをデシリアライズ

			item = JsonConvert.DeserializeObject<Item>(result);

			Debug.WriteLine(item.list[2]["main"]);
			//Debug.WriteLine(item.forecasts[0]["temperature"]);
			//Debug.WriteLine(item.forecasts[0]["date"]);

			//Debug.WriteLine(JsonConvert.DeserializeObject(result).ToString());
			return;
		}
	}

	public class Item
	{

		[JsonProperty(PropertyName = "list")]
		public IDictionary<String, Object>[] list { get; set; }
	}
}
