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
