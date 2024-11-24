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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateWeather_Click(object sender, RoutedEventArgs e)
        {

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
