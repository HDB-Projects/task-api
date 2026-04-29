using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _service;

    public TasksController(TaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<TaskItem> tasks = await _service.GetAllAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        TaskItem? task = await _service.GetByIdAsync(id);
        if (task == null) return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        TaskItem created = await _service.CreateAsync(task);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool success = await _service.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}
