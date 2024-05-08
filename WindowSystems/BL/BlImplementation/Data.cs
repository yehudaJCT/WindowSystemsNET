using System.Collections.Generic;
using WindowSystems.BL.BLApi;
using WindowSystems.BL.BO;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.DLImplementation;
using WindowSystems.DL.DO;
using static Grpc.Core.Metadata;

namespace WindowSystems.BL.BlImplementation
{
    public class Data : IData
    {
        IDal dal = new Dal();

        public void Delete(int id)
        {
            DL.DO.ChatGpt chatGpt = dal.chatGpt.ReadObject(m => m.id == id);
            DL.DO.Location location = dal.location.ReadObject(m => m.id == id);
            DL.DO.Weather weather = dal.weather.ReadObject(m => m.id == id);
            DL.DO.Map map = dal.map.ReadObject(m => m.id == id);

            dal.chatGpt.Delete(chatGpt);
            dal.location.Delete(location);
            dal.weather.Delete(weather);
            dal.map.Delete(map);
        }

        public IEnumerable<BO.Data> getAllItems()
        {
            IEnumerable<DL.DO.ChatGpt> chatGpts = dal.chatGpt.ReadAll();
            IEnumerable<DL.DO.Location> locations = dal.location.ReadAll();
            IEnumerable<DL.DO.Weather> weathers = dal.weather.ReadAll();
            IEnumerable<DL.DO.Map> maps = dal.map.ReadAll();

            List<BO.Data> datas = new List<BO.Data>();
            foreach(var map in maps)
            {
                var c = chatGpts.FirstOrDefault(m => m.id == map.id);
                BO.ChatGpt chatGpt = new BO.ChatGpt(c.prompt, c.responde);

                var l = locations.FirstOrDefault(m => m.id == map.id);
                BO.Location location = new BO.Location(l.Address, l.Latitude, l.Longitude);

                var w = weathers.FirstOrDefault(m => m.id == map.id);
                BO.Weather weather = new BO.Weather(w.Temp, w.Humidity, w.Visibility);

                BO.Data data = new BO.Data
                {
                    id = map.id,
                    URL = map.URL,
                    ChatGpt = chatGpt,
                    location = location,
                    Weather = weather
                };
                datas.Add(data);
            }


            return datas;
        }

        public BO.Data GetData(string address, int zoom, int id = -1)
        {
            int newId = 0;
            if (id == -1)
            {
                newId = dal.map.ReadAll().Count();
            }
            else
            {
                newId = id;
            }

            var loc = dal.location.Read(new DL.DO.Location(newId, address));


            DL.DO.Location DOlocation = new DL.DO.Location(loc.Result.id, loc.Result.Address, loc.Result.Latitude, loc.Result.Latitude);


            var DOweather = dal.weather.Read(new DL.DO.Weather(DOlocation));
            var DOmap = dal.map.Read(new DL.DO.Map(DOlocation, zoom));

            BO.Location location = new BO.Location
            {
                Address = loc.Result.Address,
                Latitude = loc.Result.Latitude,
                Longitude = loc.Result.Latitude 
            };

            BO.Weather weather = new BO.Weather
            {
                Temp = DOweather.Result.Temp,
                Humidity = DOweather.Result.Humidity,
                Visibility = DOweather.Result.Visibility
            };

            BO.Data data = new BO.Data
            {
                id = newId,
                URL = DOmap.Result.URL,
                location = location,
                Weather = weather
            };

            return data;
        }

        public BO.ChatGpt GetResponde(int id, string Prompt)
        {
            var c = dal.chatGpt.Read(new DL.DO.ChatGpt(id, Prompt));

            BO.ChatGpt chatGpt = new BO.ChatGpt
            {
                prompt = Prompt,
                responde = c.Result.responde
            };

            return chatGpt;
        }

        public bool validateAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
