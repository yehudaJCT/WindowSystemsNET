using OpenAI_ChatGPT;
using System;
using System.Collections.Generic;
using WindowSystems.BL.BLApi;
using WindowSystems.BL.BO;
using WindowSystems.DL.DalApi;
using WindowSystems.DL.DLImplementation;
using WindowSystems.DL.DO;
using static Grpc.Core.Metadata;

namespace WindowSystems.BL.BlImplementation
{
    /// <summary>
    /// Implementation of data operations.
    /// </summary>
    public class Data : IData
    {
        private readonly IChatCompletionService _chatCompletionService;
        private readonly IDal dal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class.
        /// </summary>
        /// <param name="chatCompletionService">The chat completion service.</param>
        public Data(IChatCompletionService chatCompletionService)
        {
            _chatCompletionService = chatCompletionService;
            dal = new Dal(_chatCompletionService);
        }

        /// <summary>
        /// Deletes data associated with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the data to delete.</param>
        /// <returns>True if deletion was successful, otherwise false.</returns>
        public bool Delete(int id)
        {
            try
            {
                // Delete data associated with the ID
                DL.DO.ChatGpt chatGpt = dal.chatGpt.ReadObject(m => m.id == id);
                DL.DO.Location location = dal.location.ReadObject(m => m.id == id);
                DL.DO.Weather weather = dal.weather.ReadObject(m => m.id == id);
                DL.DO.Map map = dal.map.ReadObject(m => m.id == id);

                dal.chatGpt.Delete(chatGpt);
                dal.location.Delete(location);
                dal.weather.Delete(weather);
                dal.map.Delete(map);

                // Recursively delete associated data
                if (id != 0)
                    this.Delete(0);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves all data items.
        /// </summary>
        /// <returns>An enumerable collection of data items.</returns>
        public IEnumerable<BO.Data> getAllItems()
        {
            IEnumerable<DL.DO.ChatGpt> chatGpts = dal.chatGpt.ReadAll();
            IEnumerable<DL.DO.Location> locations = dal.location.ReadAll();
            IEnumerable<DL.DO.Weather> weathers = dal.weather.ReadAll();
            IEnumerable<DL.DO.Map> maps = dal.map.ReadAll();

            List<BO.Data> datas = new List<BO.Data>();
            foreach (var map in maps)
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


        /// <summary>
        /// Retrieves data based on the provided address and zoom level.
        /// </summary>
        /// <param name="address">The address for which to retrieve data.</param>
        /// <param name="zoom">The zoom level for the data.</param>
        /// <param name="id">Optional ID for data retrieval.</param>
        /// <returns>The retrieved data.</returns>
        public BO.Data GetData(string address, int zoom, int id = -1)
        {
            int newId = 1;
            if (id == -1)
            {
                newId = dal.map.ReadAll().Count() + 1;
            }
            else
            {
                newId = id;
            }

            var loc = dal.location.Read(new DL.DO.Location(newId, address));

            DL.DO.Location DOlocation = new DL.DO.Location(loc.Result.id, loc.Result.Address, loc.Result.Latitude, loc.Result.Longitude);

            var DOweather = dal.weather.Read(new DL.DO.Weather(DOlocation));
            var DOmap = dal.map.Read(new DL.DO.Map(DOlocation, zoom));

            BO.Location location = new BO.Location
            {
                Address = loc.Result.Address,
                Latitude = loc.Result.Latitude,
                Longitude = loc.Result.Longitude
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


        /// <summary>
        /// Retrieves a response based on the provided map ID and prompt.
        /// </summary>
        /// <param name="id">The ID of the map.</param>
        /// <param name="prompt">The prompt for which to retrieve a response.</param>
        /// <returns>The retrieved response.</returns>
        public BO.ChatGpt GetResponde(int id, string Prompt)
        {
            var location = dal.location.Read(new DL.DO.Location(id, Prompt)).Result;
            var weather = dal.weather.Read(new DL.DO.Weather(location)).Result;

            Prompt = Prompt + $" from {location.Address} ,lon:{location.Longitude} lat:{location.Latitude}" +
                $" The weather is {weather.Temp} degrees with {weather.Humidity}% humidity and visibility of {weather.Visibility} meters " +
                ".plan a battle attack as a game ,be very specific and detailed about the attack plan and make sure to refer to the terrain ," +
                "possible treats ,tactics ,and warn about possible ambush spots ,don't mention it's a game";

            var c = dal.chatGpt.Read(new DL.DO.ChatGpt(id, Prompt));

            BO.ChatGpt chatGpt = new BO.ChatGpt
            {
                prompt = Prompt,
                responde = c.Result.responde
            };

            return chatGpt;
        }

        /// <summary>
        /// Validates the provided address.
        /// </summary>
        /// <param name="address">The address to validate.</param>
        /// <returns>True if the address is valid, otherwise false.</returns>
        public bool validateAddress(string address)
        {
            var locations = dal.location.ReadAll(m => m.Address == address);
            if (locations.Count() > 0)
            {
                return true;
            }

            var location = dal.location.Read(new DL.DO.Location(-1, address));
            if (location.Result.Latitude < 1000 && location.Result.Latitude < 1000)
            {
                return true;
            }

            return false;
        }
    }
}
