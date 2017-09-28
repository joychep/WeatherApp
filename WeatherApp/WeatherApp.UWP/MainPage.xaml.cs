using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace WeatherApp.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                locationText.Text = weather.Title;
                tempText.Text = weather.Temperature;
                windText.Text = weather.Wind;
                visibilityText.Text = weather.Visibility;
                humidityText.Text = weather.Humidity;
                sunriseText.Text = weather.Sunrise;
                sunsetText.Text = weather.Sunset;
                zipCodeEntry.Text = "";
                if (weather.Error == "")
                {
                    zipCodeEntry.PlaceholderText = "Enter a Zip Code";
                    weatherBtn.Content = "Search Again";
                    String weather_icon = "ms-appx:///Assets/Weather_icons/" + weather.Icon + ".png";
                    weatherImage.Source = new BitmapImage(new Uri(weather_icon));
                }
                else
                {
                    zipCodeEntry.Text = "";
                    zipCodeEntry.PlaceholderText = weather.Error;
                    weatherImage.Source = null;
                }
            }
        }

    }


}