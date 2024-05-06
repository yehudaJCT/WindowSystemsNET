﻿namespace WindowSystems.BL.BO;
public struct Location
{
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Location(string address, double latitude, double longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }
}