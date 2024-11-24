using System;
using System.Collections.Generic;
using System.Data.SQLite;
using static Weather_drachev_galkin.MainWindow;

namespace Weather_drachev_galkin
{
    public static class WeatherCache
    {
        private const string DbPath = "weatherCache.db";
        public static void InitializeDatabase()
        {
            if (!System.IO.File.Exists(DbPath))
            {
                SQLiteConnection.CreateFile(DbPath);
            }

            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS WeatherData (
                    City TEXT NOT NULL,
                    DateTime TEXT NOT NULL,
                    Temperature TEXT,
                    Pressure TEXT,
                    Humidity TEXT,
                    WindSpeed TEXT,
                    FeelsLike TEXT,
                    WeatherDescription TEXT,
                    RequestDate TEXT NOT NULL
                )";

                var command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
        }
        public static List<WeatherData> GetWeatherData(string city)
        {
            List<WeatherData> weatherDataList = new List<WeatherData>();

            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();
                string selectQuery = @"
                SELECT * FROM WeatherData
                WHERE City = @City AND RequestDate = @RequestDate";

                var command = new SQLiteCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@RequestDate", DateTime.Now.ToString("yyyy-MM-dd"));

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        weatherDataList.Add(new WeatherData
                        {
                            DateTime = reader["DateTime"].ToString(),
                            Temperature = reader["Temperature"].ToString(),
                            Pressure = reader["Pressure"].ToString(),
                            Humidity = reader["Humidity"].ToString(),
                            WindSpeed = reader["WindSpeed"].ToString(),
                            FeelsLike = reader["FeelsLike"].ToString(),
                            WeatherDescription = reader["WeatherDescription"].ToString()
                        });
                    }
                }
            }

            return weatherDataList;
        }
        public static int GetRequestCountForToday()
        {
            int requestCount = 0;

            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM WeatherData WHERE RequestDate = @RequestDate";
                var command = new SQLiteCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@RequestDate", DateTime.Now.ToString("yyyy-MM-dd"));

                requestCount = Convert.ToInt32(command.ExecuteScalar());
            }

            return requestCount;
        }
    }

}
