using Microsoft.AspNetCore.Mvc;
using WindowSystems.BL.BLApi;
using WindowSystems.BL.BlImplementation;
using WindowSystems.BL.BO;


namespace WindowSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        IBl _dataService = new Bl();

        public DataController(Bl dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("IsALocation")]
        public IActionResult IsALocation(string address)
        {
            bool result = _dataService.data.IsALocation(address);

            return Ok(result);
        }

        [HttpGet("GetData")]
        public IActionResult GetData(string address, DateTime dateTime)
        {
            var data = _dataService.data.GetData(address, dateTime);

            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("GetResponse")]
        public IActionResult GetResponse(string URL, string Prompt)
        {
            var response = _dataService.data.GetResponde(URL, Prompt);

            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string URL)
        {
            _dataService.data.Delete(URL);
            return NoContent();
        }
    }
}
