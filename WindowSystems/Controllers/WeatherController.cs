

namespace WindowSystems.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class WeatherController : ControllerBase
    //{
    //    private readonly IWeather _weatherRepository;

    //    public WeatherController(IWeather weatherRepository)
    //    {
    //        _weatherRepository = weatherRepository;
    //    }

    //    [HttpPost]
    //    public IActionResult Create(Weather weather)
    //    {
    //        _weatherRepository.Create(weather);
    //        return Ok();
    //    }

    //    [HttpGet("{Date}")]
    //    public IActionResult Read(DateTime Date)
    //    {
    //        var weather = _weatherRepository.ReadObject(w => w.Date == Date);
    //        if (weather == null)
    //            return NotFound();
    //        return Ok(weather);
    //    }

    //    [HttpPut("{Date}")]
    //    public IActionResult Update(DateTime Date, Weather weather)
    //    {
    //        var existingWeather = _weatherRepository.ReadObject(w => w.Date == Date);
    //        if (existingWeather == null)
    //            return NotFound();

    //        weather.Date = Date;
    //        _weatherRepository.Update(weather);
    //        return NoContent();
    //    }

    //    [HttpDelete("{Date}")]
    //    public IActionResult Delete(DateTime Date)
    //    {
    //        var existingWeather = _weatherRepository.ReadObject(w => w.Date == Date);
    //        if (existingWeather == null)
    //            return NotFound();

    //        _weatherRepository.Delete(existingWeather);
    //        return NoContent();
    //    }

    //    [HttpGet]
    //    public IActionResult ReadAll()
    //    {
    //        var allWeather = _weatherRepository.ReadAll();
    //        return Ok(allWeather);
    //    }
    //}
}
