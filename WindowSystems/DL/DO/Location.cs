namespace WindowSystems.DL.DO;

public struct Location
{
    public int id { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Location(int id, string address, double latitude, double longitude)
    {
        this.id = id;
        this.Address = address;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }
}