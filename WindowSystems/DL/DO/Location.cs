namespace WindowSystems.DL.DO;

public struct Location
{
    public int id { get; }
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public Location(int id, string address, double latitude, double longitude)
    {
        this.id = id;
        this.Address = address;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    public Location(int id, string address)
    {
        this.id = id;
        this.Address = address;
    }

}