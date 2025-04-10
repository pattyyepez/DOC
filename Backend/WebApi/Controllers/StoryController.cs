using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("api/stories")]
public class StoryController : ControllerBase
{
    private readonly IStoryService _service;
    private readonly ILogger<StoryController> _logger;

    public StoryController(IStoryService service, ILogger<StoryController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Story> list = await _service.GetAll();
        return Ok(list);
    }
}