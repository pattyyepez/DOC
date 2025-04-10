using Entities;

namespace WebApi.Services;

public interface IStoryService
{ 
    Task<Story> AddAsync(Story story);
    Task<List<Story>> GetAll();

}