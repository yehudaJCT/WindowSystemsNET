namespace WindowSystems.BL.BO
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

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}, Temperature: {Temperature}°C, Chance of Rain: {ChanceOfRain}%, Visibility: {Visibility}km";
        }

    }
}
