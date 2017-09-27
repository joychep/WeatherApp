using System;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid  
            string key = "71e7d2369e9c291174795d5d52cf8e20";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + ",us&appid=" + key + "&units=imperial";

            //Make sure developers running this sample replaced the API key
            if (key == "YOUR API KEY HERE")
            {
                throw new ArgumentException("You must obtain an API key from openweathermap.org/appid and save it in the 'key' variable.");
            }

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                int temp = (int)results["main"]["temp"];
                weather.Temperature = temp.ToString() + (Char)176 + " C";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = "Humidity" +(string)results["main"]["humidity"] + " %";
                weather.Visibility = "Visibility: " + (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                sunrise.ToLocalTime();
                weather.Sunrise = "Sunrise: " + sunrise.ToString() + " UTC";
                weather.Sunset = "Sunset: " + sunset.ToString() + " UTC";
                weather.Error = "";
                return weather;
            }
            else
            {
                Weather weather = new Weather();
                weather.Error = "Enter a valid Zip Code";
                return weather;
            }
        }
    }
}
