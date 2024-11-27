using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Weather_drachev_galkin
{
    public partial class MainWindow : Window
    {
        private const string ApiKey = "64440d6f2fc047443c94bf721a6ae091";
        private const string ApiUrl = "https://api.openweathermap.org/data/2.5/forecast?q={0}&appid={1}&units=metric&lang=ru";

        public MainWindow()
        {
            InitializeComponent();
            WeatherCache.InitializeDatabase();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string defaultCity = "Пермь";
            await UpdateWeather(defaultCity);
            UpdateRequestCount();
        }

        private async void UpdateWeather_Click(object sender, RoutedEventArgs e)
        {
            string city = CityTextBox.Text.Trim();

            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Пожалуйста, введите название города.");
                return;
            }

            await UpdateWeather(city);
            UpdateRequestCount();
        }

        private async Task UpdateWeather(string city)
        {
            try
            {
                int requestCount = WeatherCache.GetRequestCountForToday();

                if (requestCount >= 200)
                {
                    var cachedData = WeatherCache.GetWeatherData(city);
                    if (cachedData.Count > 0)
                    {
                        WeatherDataGrid.ItemsSource = cachedData;
                        MessageBox.Show("Данные для города получены из кэша.");
                    }
                    else
                    {
                        MessageBox.Show("Лимит запросов на сегодня превышен, и кэшированных данных нет.");
                    }
                }
                else
                {
                    var weatherData = await FetchWeatherData(city);
                    WeatherDataGrid.ItemsSource = weatherData;

                    foreach (var data in weatherData)
                    {
                        WeatherCache.SaveWeatherData(city, data.DateTime, data.Temperature, data.Pressure, data.Humidity, data.WindSpeed, data.FeelsLike, data.WeatherDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private async Task<List<WeatherData>> FetchWeatherData(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format(ApiUrl, city, ApiKey);
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Ошибка {response.StatusCode}: {response.ReasonPhrase}");
                }

                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<dynamic>(responseBody);

                var weatherList = new List<WeatherData>();

                foreach (var item in json.list)
                {
                    weatherList.Add(new WeatherData
                    {
                        DateTime = Convert.ToDateTime(item.dt_txt).ToString("dd.MM.yyyy HH:mm"),
                        Temperature = $"{item.main.temp} °C",
                        Pressure = $"{item.main.pressure} мм рт. ст.",
                        Humidity = $"{item.main.humidity}%",
                        WindSpeed = $"{item.wind.speed} м/с",
                        FeelsLike = $"{item.main.feels_like} °C",
                        WeatherDescription = item.weather[0].description.ToString()
                    });
                }

                return weatherList;
            }
        }


        private void UpdateRequestCount()
        {
            int requestCount = WeatherCache.GetRequestCountForToday();
            RequestCountTextBlock.Text = $"Количество запросов сегодня: {requestCount}";
        }
    }

    public class WeatherData
    {
        public string DateTime { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string WindSpeed { get; set; }
        public string FeelsLike { get; set; }
        public string WeatherDescription { get; set; }
    }

}
