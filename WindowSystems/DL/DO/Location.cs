namespace WindowSystems.DL.DO;

public struct Location
{
    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    public Location(string address, double latitude, double longitude)
    {
        this.Address = address;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    public Location(string address)
    {
        this.Address = address;
    }

}