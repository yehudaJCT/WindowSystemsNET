using Microsoft.AspNetCore.Mvc;
using WindowSystems.DL.DO;


namespace WindowSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        //private readonly IMap _mapRepository;

        //public MapController(IMap mapRepository)
        //{
        //    _mapRepository = mapRepository;
        //}

        //[HttpPost]
        //public IActionResult Create(Map map)
        //{
        //    _mapRepository.Create(map);
        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //public IActionResult Read(int id)
        //{
        //    var map = _mapRepository.ReadObject(m => m.Id == id);
        //    if (map == null)
        //        return NotFound();
        //    return Ok(map);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Map map)
        //{
        //    var existingMap = _mapRepository.ReadObject(m => m.Id == id);
        //    if (existingMap == null)
        //        return NotFound();

        //    map.Id = id;
        //    _mapRepository.Update(map);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var existingMap = _mapRepository.ReadObject(m => m.Id == id);
        //    if (existingMap == null)
        //        return NotFound();

        //    _mapRepository.Delete(existingMap);
        //    return NoContent();
        //}

        //[HttpGet]
        //public IActionResult ReadAll()
        //{
        //    var allMaps = _mapRepository.ReadAll();
        //    return Ok(allMaps);
        //}
    }
}
