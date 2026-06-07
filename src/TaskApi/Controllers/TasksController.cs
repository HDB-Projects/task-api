using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.DTOs;
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
    public async Task<IActionResult> Create(CreateTaskDto taskDto)
    {
        TaskItem created = await _service.CreateAsync(taskDto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        bool success = await _service.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpPost("{id}/attachments")]
    public async Task<ActionResult> UploadAttachment(
        Guid id,
        IFormFile file,
        [FromServices] IFileStorageService storageService,
        [FromServices] AppDbContext context)
    {
        TaskItem? task = await context.Tasks.FindAsync(id);

        if (task is null)
            return NotFound("Task not found.");

        if (file.Length == 0)
            return BadRequest("File is empty.");

        await using Stream stream = file.OpenReadStream();

        string storedFileName = await storageService.SaveFileAsync(
            stream,
            file.FileName);

        FileUploadMetadata metadata = new FileUploadMetadata
        {
            OriginalFileName = file.FileName,
            ContentType = file.ContentType,
            Size = file.Length
        };

        Attachment attachment = Attachment.Create(task.Id, metadata, storedFileName);

        context.Attachments.Add(attachment);

        await context.SaveChangesAsync();

        return Ok(new {FileName = storedFileName});
    }
}
