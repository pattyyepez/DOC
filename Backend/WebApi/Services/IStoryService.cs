using Entities;

namespace WebApi.Services;

public interface IStoryService
{ 
    Task<List<Story>> GetAll();

}