using Database;
using Entities;

namespace WebApi.Services;

public class EfcStoryService : IStoryService
{
    private readonly TabloidDataAccess _access;
    private readonly ILogger<EfcStoryService> _logger;
    
    public EfcStoryService(ViaTabloidDbContext dbContext, ILogger<EfcStoryService> logger)
    {
        _access = new TabloidDataAccess(dbContext);
        _logger = logger;
    }

    public async Task<List<Story>> GetAll()
    {
        return await _access.GetAllStoriesAsync();
    }
    
    
}