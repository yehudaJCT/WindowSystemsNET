using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OpenAI_ChatGPT;
using WindowSystems.BL.BlImplementation;

/// <summary>
/// Controller for managing data operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly IChatCompletionService _chatCompletionService;
    private readonly Bl bl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataController"/> class.
    /// </summary>
    /// <param name="chatCompletionService">The chat completion service.</param>
    public DataController(IChatCompletionService chatCompletionService)
    {
        _chatCompletionService = chatCompletionService;
        bl = new Bl(chatCompletionService);
    }

    /// <summary>
    /// Validates whether the provided address is a location.
    /// </summary>
    /// <param name="address">The address to validate.</param>
    /// <returns>A JSON result indicating whether the address is valid.</returns>
    [HttpGet("IsALocation")]
    public IActionResult ValidateAddress(string address)
    {
        var isValid = bl.data.validateAddress(address);
        return Ok(new { isValid = isValid });
    }

    /// <summary>
    /// Retrieves data based on the provided address and zoom level.
    /// </summary>
    /// <param name="address">The address for which to retrieve data.</param>
    /// <param name="zoom">The zoom level for the data.</param>
    /// <returns>A JSON result containing the retrieved data.</returns>
    [HttpGet("GetData")]
    public IActionResult GetData(string address, int zoom)
    {
        var data = bl.data.GetData(address, zoom);
        return Ok(new { data = data });
    }

    /// <summary>
    /// Retrieves a response based on the provided map ID and prompt.
    /// </summary>
    /// <param name="id_map">The ID of the map.</param>
    /// <param name="prompt">The prompt for which to retrieve a response.</param>
    /// <returns>A JSON result containing the retrieved response.</returns>
    [HttpGet("GetResponse")]
    public IActionResult GetResponse(int id_map, string prompt)
    {
        var response = bl.data.GetResponde(id_map, prompt);
        return Ok(new { response = response });
    }

    /// <summary>
    /// Deletes an item with the specified map ID.
    /// </summary>
    /// <param name="id_map">The ID of the map item to delete.</param>
    /// <returns>A JSON result indicating whether the item was deleted successfully.</returns>
    [HttpGet("Delete")]
    public IActionResult Delete(int id_map)
    {
        var isDeleted = bl.data.Delete(id_map);
        return Ok(new { isDeleted = isDeleted });
    }

    /// <summary>
    /// Retrieves all items.
    /// </summary>
    /// <returns>A JSON result containing all retrieved items.</returns>
    [HttpGet("GetAllItems")]
    public IActionResult GetAllItems()
    {
        var items = bl.data.getAllItems();
        return Ok(new { items = items });
    }
}
