using Database;
using DTOs;
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

    public async Task<StoryDto> AddAsync(CreateStoryDto story)
    {
        Story temp = new Story()
        {
            Title = story.Title,
            Content = story.Content,
            DepartmentId = story.DepartmentId,
        };
        
        temp = await _access.CreateStoryAsync(temp);

        StoryDto toReturn = new StoryDto()
        {
            Id = temp.Id,
            Title = temp.Title,
            Content = temp.Content,
            CreatedAt = temp.CreatedAt,
            DepartmentId = temp.DepartmentId,
        };

        return toReturn;
    }

    public async Task<List<StoryDto>> GetAll()
    {
        List<StoryDto> toReturn = (await _access.GetAllStoriesAsync())
            .Select(x => new StoryDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CreatedAt = x.CreatedAt,
                DepartmentId = x.DepartmentId,
            })
            .ToList();
        return toReturn;
    }
    
    
}