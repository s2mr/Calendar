using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Calendar
{
	public static class ForecastManager
	{

	   static Item item;

		//string weather { get; set; }

		//public double minTemperature
		//{
		//	get
		//	{
		//		var dict = item.list[2]["main"] as Dictionary<String, String>;
		//		string str = dict["temp_min"];
		//		double doubleVal = Convert.ToDouble(str);

		//		return doubleVal - 273.15;
		//	}
		//}

		//public double maxTemperature
		//{
		//	get
		//	{
		//		var dict = item.list[2]["main"] as Dictionary<String, String>;
		//		string str = dict["temp_max"];
		//		double doubleVal = Convert.ToDouble(str);

		//		return doubleVal - 273.15;
		//	}
		//}

		public static double getMinTemperature()
		{
			JObject dict = item.list[5]["main"] as JObject;
			var dict2 = dict.ToObject<Dictionary<String, String>>();
			var dict3 = dict2["temp_min"];
			double doubleVal = Convert.ToDouble(dict3);

			return doubleVal - 273.15;
		}

		public static double getMaxTemperature()
		{
			JObject dict = item.list[3]["main"] as JObject;
			var dict2 = dict.ToObject<Dictionary<String, String>>();
			var dict3 = dict2["temp_max"];
			double doubleVal = Convert.ToDouble(dict3);

			return doubleVal - 273.15;
		}

		public static string getWeatherIconName()
		{
			var dict = item.list[3]["weather"] as JArray;
			var dict2 = dict[0].ToObject<Dictionary<String, Object>>();
			var str = dict2["icon"].ToString();

			return String.Format("http://openweathermap.org/img/w/{0}.png", str);

			//return str;
		}

		public static string getWeather()
		{
			var dict = item.list[3]["weather"] as JArray;
			var dict2 = dict[0].ToObject<Dictionary<String, Object>>();
			var str = dict2["main"].ToString();
			return str;
		}

		public static string getWeatherDetail()
		{
			var dict = item.list[3]["weather"] as JArray;
			var dict2 = dict[0].ToObject<Dictionary<String, Object>>();
			var str = dict2["description"].ToString();
			return str;
		}

		// データを取得するメソッド
		public static async Task AsyncGetWebAPIData()
		{
			string apiKey = "8d1d292024c6d285eeb507da0ffd0ef9";

			//string AED_URL = "http://weather.livedoor.com/forecast/webservice/json/v1?city=030010";

			string newUrl = "http://api.openweathermap.org/data/2.5/forecast?id=2111834&appid=8d1d292024c6d285eeb507da0ffd0ef9";
			//string weatherUrl = "http://api.openweathermap.org/data/2.5/forecast/city?id=2110657&APPID=8d1d292024c6d285eeb507da0ffd0ef9";
			// HttpClientの作成 
			HttpClient httpClient = new HttpClient();
			// 非同期でAPIからデータを取得
			Task<string> stringAsync = httpClient.GetStringAsync(newUrl);
			string result = await stringAsync;
			// JSON形式のデータをデシリアライズ

			item = JsonConvert.DeserializeObject<Item>(result);

				Debug.WriteLine(item.list[2]["main"]);
			Debug.WriteLine(item.list[2]["weather"]);
			//Debug.WriteLine(item.forecasts[0]["temperature"]);
			//Debug.WriteLine(item.forecasts[0]["date"]);
			return;
		}
	}

	public class Item
	{

		[JsonProperty(PropertyName = "list")]
		 public IDictionary<String, Object>[] list { get; set; }
	}
}
