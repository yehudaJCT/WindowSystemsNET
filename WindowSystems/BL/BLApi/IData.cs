using Microsoft.Identity.Client;
using System.Net;
using WindowSystems.BL.BO;
using WindowSystems.DL.DalApi;

namespace WindowSystems.BL.BLApi
{
    //    validateAddress(address)-> bool:(True if the address is valid, False otherwise)
    //    getData(address, date)-> json:(weather and map data)
    //    getResponse(id_map, prompt)-> json:(updated item is included by checking the id_map and prompt)
    //    delete(id_map)-> bool:(True if the item is deleted, False otherwise)
    //    getAllItems()-> json:(all items from the SQL database)

    public interface IData
    {
        public bool validateAddress(string address);

        public Data GetData(string address, int zoom, int id = -1);

        public ChatGpt GetResponde(int id, string Prompt);

        public bool Delete(int id);

        public IEnumerable<Data> getAllItems();

    }
}
