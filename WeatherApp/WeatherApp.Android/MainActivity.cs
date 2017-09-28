using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace WeatherApp.Droid
{
	[Activity (Label = "Weather", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private object context;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.weatherBtn);

            button.Click += Button_Click;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            EditText zipCodeEntry = FindViewById<EditText>(Resource.Id.zipCodeEntry);

            if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                FindViewById<TextView>(Resource.Id.locationText).Text = weather.Title;
                FindViewById<TextView>(Resource.Id.tempText).Text = weather.Temperature;
                FindViewById<TextView>(Resource.Id.windText).Text = weather.Wind;
                FindViewById<TextView>(Resource.Id.visibilityText).Text = weather.Visibility;
                FindViewById<TextView>(Resource.Id.humidityText).Text = weather.Humidity;
                FindViewById<TextView>(Resource.Id.sunriseText).Text = weather.Sunrise;
                FindViewById<TextView>(Resource.Id.sunsetText).Text = weather.Sunset;
                //FindViewById<TextView>(Resource.Id.errorText).Text = weather.Error;
                var imageView = FindViewById<ImageView>(Resource.Id.imageView1);
                //  int drawResource = Integer.("Resource.Drawable.b"+ weather.Error);
                if (weather.Icon == "01d")
                {
                    imageView.SetImageResource(Resource.Drawable.b01d);
                }
                else if (weather.Icon == "01n")
                {
                    imageView.SetImageResource(Resource.Drawable.b01n);
                }
                else if (weather.Icon == "09d")
                {
                    imageView.SetImageResource(Resource.Drawable.b09d);
                }
                else if (weather.Icon == "10d")
                {
                    imageView.SetImageResource(Resource.Drawable.b10d);
                }
                else if (weather.Icon == "11d")
                {
                    imageView.SetImageResource(Resource.Drawable.b11d);
                }
                else if (weather.Icon == "13d")
                {
                    imageView.SetImageResource(Resource.Drawable.b13d);
                }
                else if (weather.Icon == "50d")
                {
                    imageView.SetImageResource(Resource.Drawable.b50d);
                }
                else
                {
                    imageView.SetImageResource(Resource.Drawable.b01d);
                }
              
            }
        }
    }
}


