using Database;
using Entities;
using Microsoft.AspNetCore.Mvc;

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

    public Task<Story> AddAsync(Story story)
    {
        return _access.CreateStoryAsync(story);
    }

    public async Task<List<Story>> GetAll()
    {
        return await _access.GetAllStoriesAsync();
    }
    
    
}