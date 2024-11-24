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
