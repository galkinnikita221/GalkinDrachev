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
    }

}
