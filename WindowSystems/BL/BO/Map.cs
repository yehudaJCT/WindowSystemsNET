namespace WindowSystems.BL.BO
{
    public class Map
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int Zoom { get; private set; }
        public string Url { get; private set; }

        public Map(double latitude, double longitude, int zoom, string Url)
        {
            Latitude = latitude;
            Longitude = longitude;
            Zoom = zoom;
            this.Url = Url;
        }

        public override string ToString()
        {
            return $"Latitude: {Latitude}, Longitude: {Longitude}, Zoom: {Zoom}, URL: {Url}";
        }
    }
}
