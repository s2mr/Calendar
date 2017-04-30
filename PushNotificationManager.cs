using System;
using System.Diagnostics;
using System.IO;
using System.Net;
//using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Calendar
{
    public class PushNotificationManager
    {
        static string _uri = "https://fcm.googleapis.com/fcm/send";

        static public void SendPushNotification()
        {
            var tm = new TrashManager();
            var json = new JObject(
                new JProperty("to", Config.token),
                new JProperty("priority", "high"),
                new JProperty("notification", new JObject(
                    new JProperty("title", "ゴミ出し"),
                    new JProperty("body", tm.GetTodayTomorrowString() + tm.GetTrashString() + "です。")
                            )));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_uri);
            request.ContentType = "application/json";
            request.Headers[HttpRequestHeader.Authorization] = "key=" + Config.serverKey;
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStreamAsync().Result))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Dispose();
                try
                {
                    var httpResponse = (HttpWebResponse)request.GetResponseAsync().Result;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        Debug.WriteLine("Response Body: \r\n {0}", result);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception {0}", ex);
                }
            }
        }
    }
}
