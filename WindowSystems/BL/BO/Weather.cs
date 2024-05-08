namespace WindowSystems.BL.BO
{
    public class Weather
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }

        public Weather(double Temp, int Humidity, int Visibility)
        {
            this.Temp = Temp;
            this.Humidity = Humidity;
            this.Visibility = Visibility;
        }

        public Weather() { }
    }
}
