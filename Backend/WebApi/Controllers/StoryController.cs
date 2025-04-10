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
    
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] Story story)
    {
        var response = await _service.AddAsync(story);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        List<Story> list = await _service.GetAll();
        return Ok(list);
    }
}