namespace WindowSystems.BL.BO
{
    public class WeatherTest
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; } // Temperature in Celsius
        public int ChanceOfRain { get; set; } // Percentage
        public double Visibility { get; set; } // Visibility in kilometers

        public WeatherTest(DateTime date, double temperature, int chanceOfRain, double visibility)
        {
            Date = date;
            Temperature = temperature;
            ChanceOfRain = chanceOfRain;
            Visibility = visibility;
        }
    }
}
