namespace WindowSystems.model
{
    public class AggregatedData
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int Zoom { get; private set; }
        public string Url { get; private set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; } // Temperature in Celsius
        public int ChanceOfRain { get; set; } // Percentage
        public double Visibility { get; set; } // Visibility in kilometers

        public AggregatedData(double latitude, double longitude, int zoom, string url, DateTime date, double temperature, int chanceOfRain, double visibility)
        {
            Latitude = latitude;
            Longitude = longitude;
            Zoom = zoom;
            Url = url;
            Date = date;
            Temperature = temperature;
            ChanceOfRain = chanceOfRain;
            Visibility = visibility;
        }
    }
}
