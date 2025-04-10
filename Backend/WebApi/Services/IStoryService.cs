using DTOs;
using Entities;

namespace WebApi.Services;

public interface IStoryService
{ 
    Task<StoryDto> AddAsync(CreateStoryDto story);
    Task<List<StoryDto>> GetAll();

}