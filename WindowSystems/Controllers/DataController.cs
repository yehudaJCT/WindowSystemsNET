using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OpenAI_ChatGPT;
using WindowSystems.BL.BlImplementation;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly IChatCompletionService _chatCompletionService;
    private readonly Bl bl;

    public DataController(IChatCompletionService chatCompletionService)
    {
        _chatCompletionService = chatCompletionService;
        bl = new Bl(chatCompletionService);
    }

    [HttpGet("IsALocation")]
    public IActionResult ValidateAddress(string address)
    {
        var isValid = bl.data.validateAddress(address);
        return Ok(new { isValid = isValid });
    }

    [HttpGet("GetData")]
    public IActionResult GetData(string address, int zoom)
    {
        var data = bl.data.GetData(address, zoom);
        return Ok(data);
    }

    [HttpGet("GetResponse")]
    public IActionResult GetResponse(int id_map, string prompt)
    {
        var response = bl.data.GetResponde(id_map, prompt);
        return Ok(response);
    }

    [HttpGet("Delete")]
    public IActionResult Delete(int id_map)
    {
        var isDeleted = bl.data.Delete(id_map);
        return Ok(isDeleted);
    }

    [HttpGet("GetAllItems")]
    public IActionResult GetAllItems()
    {
        var items = bl.data.getAllItems();
        return Ok(items);
    }
}