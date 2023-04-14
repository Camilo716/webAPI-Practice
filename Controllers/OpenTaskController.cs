using Microsoft.AspNetCore.Mvc;
using webAPI.Services;
using webAPI.Models;

namespace webAPI.Controllers;

[Route("api/[controller]")]
public class OpenTaskController : ControllerBase
{
    private readonly ILogger<OpenTaskController> _logger;

    private readonly IOpenTaskService _openTaskService;

    public OpenTaskController(ILogger<OpenTaskController> logger, IOpenTaskService openTaskService)
    {
        _logger = logger;
        _openTaskService = openTaskService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_openTaskService.GetOpenTasks());
    }

    [HttpPost]
    public IActionResult Post([FromBody] OpenTaskModel openTask)
    {
        _openTaskService.SaveOpenTaskAsync(openTask);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] OpenTaskModel openTask)
    {
        _openTaskService.UpdateOpenTaskAsync(id, openTask);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _openTaskService.DeleteOpenTaskAsync(id);
        return Ok();
    }
}
