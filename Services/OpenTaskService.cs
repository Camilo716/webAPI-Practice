using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class OpenTaskService : IOpenTaskService
{
    private DbWebAPIContext _context;

    public OpenTaskService(DbWebAPIContext context)
    {
        _context = context;
    }

    public IEnumerable<OpenTaskModel> GetOpenTasks()
    {
        return _context.OpenTasks;
    }

    public async Task SaveOpenTaskAsync(OpenTaskModel openTask)
    {
        _context.Add(openTask);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateOpenTaskAsync(Guid id, OpenTaskModel openTask)
    {
        OpenTaskModel? actualTask = _context.OpenTasks.Find(id);

        if (actualTask == null)
        {
            actualTask = openTask;
            actualTask.description = openTask.description;
            actualTask.Priority = openTask.Priority;

            await _context.SaveChangesAsync();
        }    
    }

    public async Task DeleteOpenTaskAsync(Guid id)
    {
        OpenTaskModel? actualTask = _context.OpenTasks.Find(id);

        if (actualTask != null)
        {
            _context.Remove(actualTask);

            await _context.SaveChangesAsync();
        }
    }
}

public interface IOpenTaskService
{
    IEnumerable<OpenTaskModel> GetOpenTasks();
    Task SaveOpenTaskAsync(OpenTaskModel openTask);
    Task UpdateOpenTaskAsync(Guid id, OpenTaskModel openTask);
    Task DeleteOpenTaskAsync(Guid id);
}