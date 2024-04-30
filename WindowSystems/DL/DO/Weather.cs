namespace WindowSystems.DL.DO
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; } // Temperature in Celsius
        public int ChanceOfRain { get; set; } // Percentage
        public double Visibility { get; set; } // Visibility in kilometers

        public Weather(DateTime date, double temperature, int chanceOfRain, double visibility)
        {
            Date = date;
            Temperature = temperature;
            ChanceOfRain = chanceOfRain;
            Visibility = visibility;
        }
    }
}
