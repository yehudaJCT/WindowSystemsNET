﻿namespace WindowSystems.BL.BO;
public class Location
{
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Location(string address, double latitude, double longitude)
    {
        this.Address = address;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    public Location() { }
}