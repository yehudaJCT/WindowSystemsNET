using Google.Api;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.model
{
    public class MyDb
    {
        [Key]
        public int id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string URL { get; set; }
        public int zoom { get; set; }
        public DateTime Date { get; set; }
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public int Visibility { get; set; }
        public string prompt;
        public string responde;

        public MyDb()
        {
            this.id = -1;
            this.Latitude = -1;
            this.Longitude = -1;
            this.Address = "";
            this.URL = "";
            this.zoom = -1;
            //this.Date = ?
            this.Temp = -1;
            this.Humidity = -1;
            this.Visibility = -1;
            this.prompt = "";
            this.responde = "";
        }

        public MyDb(Map Map)
        {
            this.id = Map.id;
            this.Latitude = Map.Location.Latitude;
            this.Longitude = Map.Location.Longitude;
            this.Address = Map.Location.Address;
            this.URL = Map.URL;
            this.zoom = Map.zoom;
        }

        public MyDb(ChatGpt chatGpt)
        {
            this.id = chatGpt.id;
            this.prompt = chatGpt.prompt;
            this.responde = chatGpt.responde;

        }

        public MyDb(Location location)
        {
            this.id = location.id;
            this.Address = location.Address;
            this.Latitude = location.Latitude;
            this.Longitude = location.Longitude;    
        }

        public MyDb(Weather weather)
        {
            this.id = weather.id;
            this.Latitude = weather.Location.Latitude;
            this.Longitude = weather.Location.Longitude;
            this.Date = weather.Date;
            this.Temp = weather.Temp;
            this.Humidity = weather.Humidity;
            this.Visibility = weather.Visibility;
        }

        public MyDb(MyDb map)
        {
            this.id = map.id;
            this.Latitude = map.Latitude;
            this.Longitude = map.Longitude;
            this.Address = map.Address;
            this.URL = map.URL;
            this.zoom = map.zoom;
        }

        public DO.Map MapConverter(MyDb sMap)
        {
            DO.Location location = new Location(sMap.id, sMap.Address, sMap.Latitude, sMap.Longitude);
            DO.Map map = new Map(location, sMap.URL, sMap.zoom);
            return map;
        }

        public DO.ChatGpt ChatGptConverter(MyDb sMap)
        {
            DO.ChatGpt chatGpt = new ChatGpt(sMap.id, sMap.prompt, sMap.responde);
            return chatGpt;
        }

        public DO.Location LocationConverter(MyDb sMap)
        {
            DO.Location location = new Location(sMap.id, sMap.Address, sMap.Latitude, sMap.Longitude);
            return location;
        }

        public DO.Weather WeatherConverter(MyDb sMap)
        {
            DO.Location location = new Location(sMap.id, sMap.Address, sMap.Latitude, sMap.Longitude);
            DO.Weather weather = new Weather(location, sMap.Date, sMap.Temp, sMap.Humidity, sMap.Visibility);
            return weather;
        }
    }
}
