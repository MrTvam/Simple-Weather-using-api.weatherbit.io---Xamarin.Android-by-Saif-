using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Weather
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            FirstPage();

        }

        void FirstPage()
        {
            SetContentView(Resource.Layout.FirstPage);
            var City = FindViewById<EditText>(Resource.Id.editText1);
            var Submit = FindViewById<Button>(Resource.Id.SubmitButton);

            Submit.Click += delegate
            {

                GetWeather(City.Text);

            };
        }
        async void GetWeather(string place)
        {
            var textView1 = FindViewById<TextView>(Resource.Id.textView1);
            string apiKey = "ec498e849a7d4164aeefafecd336418e";
            string apiBase = "https://api.weatherbit.io/v2.0/current?city=";
            if (string.IsNullOrEmpty(place))
            {
                Toast.MakeText(this, "please enter a valid city name", ToastLength.Short).Show();
                return;
            }

            if (!CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "No internet connection", ToastLength.Short).Show();
                return;
            }
            // Asynchronous API call using HttpClient
            string url = apiBase + place + "&key=" + apiKey;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

            Console.WriteLine(result);

            var resultObject = JObject.Parse(result);


            string country = resultObject["data"][0]["country_code"].ToString();
            string placename = resultObject["data"][0]["city_name"].ToString();
            string temperature = resultObject["data"][0]["temp"].ToString();
            string Sunrise = resultObject["data"][0]["sunrise"].ToString();
            string Sunset = resultObject["data"][0]["sunset"].ToString();


            if (!string.IsNullOrEmpty(placename))
            {
                SecondPage(placename, country, temperature, Sunrise, Sunset);
            }

        }

            public void SecondPage(string  p,string c,string temp, string sr, string st)
        {
            SetContentView(Resource.Layout.SecondPage);
            var txtCity = FindViewById<TextView>(Resource.Id.txtCity);
            var txtCountry = FindViewById<TextView>(Resource.Id.txtCountry);
            var txtSunrise = FindViewById<TextView>(Resource.Id.txtSunrise);
            var txtSunset = FindViewById<TextView>(Resource.Id.txtSunset);
            var txtTemperature = FindViewById<TextView>(Resource.Id.txtTemperature);
            txtCity.Text = p;
            txtCountry.Text = c;
            txtSunrise.Text = sr;
            txtSunset.Text = st;
            txtTemperature.Text = temp;


            //back
            var back = FindViewById<Button>(Resource.Id.Back);
            back.Click += delegate
            {
                FirstPage();
            };

        }
    }
}