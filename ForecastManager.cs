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
			JObject dict = item.list[0]["temp"] as JObject;
			var dict2 = dict.ToObject<Dictionary<String, String>>();
			var dict3 = dict2["min"];
			double doubleVal = Convert.ToDouble(dict3);

			return doubleVal;
		}

		public static double getMaxTemperature()
		{
			JObject dict = item.list[0]["temp"] as JObject;
			var dict2 = dict.ToObject<Dictionary<String, String>>();
			var dict3 = dict2["max"];
			double doubleVal = Convert.ToDouble(dict3);

			return doubleVal;
		}

		public static string getWeatherIconName()
		{
			var dict = item.list[0]["weather"] as JArray;
			var dict2 = dict[0].ToObject<Dictionary<String, Object>>();
			var str = dict2["icon"].ToString();

			return String.Format("http://openweathermap.org/img/w/{0}.png", str);

			//return str;
		}

		public static string getWeather()
		{
			var dict = item.list[0]["weather"] as JArray;
			var dict2 = dict[0].ToObject<Dictionary<String, Object>>();
			var str = dict2["main"].ToString();
			return str;
		}

		public static string getWeatherDetail()
		{
			var dict = item.list[0]["weather"] as JArray;
			var dict2 = dict[0].ToObject<Dictionary<String, Object>>();
			var str = dict2["description"].ToString();
			return str;
		}

		// データを取得するメソッド
		public static async Task AsyncGetWebAPIData()
		{
			string apiKey = "8d1d292024c6d285eeb507da0ffd0ef9";
			string newUrl = "http://openweathermap.org/data/2.5/forecast/daily?id=2111834&lang=ja-jp&appid=b1b15e88fa797225412429c1c50c122a1";

			// HttpClientの作成 
			HttpClient httpClient = new HttpClient();
			// 非同期でAPIからデータを取得
			Task<string> stringAsync = httpClient.GetStringAsync(newUrl);
			string result = await stringAsync;
			// JSON形式のデータをデシリアライズ

			item = JsonConvert.DeserializeObject<Item>(result);

				Debug.WriteLine(item.list[0]["temp"]);
			Debug.WriteLine(item.list[0]["weather"]);

			return;
		}
	}

	public class Item
	{

		[JsonProperty(PropertyName = "list")]
		 public IDictionary<String, Object>[] list { get; set; }
	}
}
