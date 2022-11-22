using DatingApp.API.DTOs;
using DatingApp.API.ViewModels;

namespace DatingApp.API.Interface
{
    public interface IPublisherService
    {
        Task<int> AddPublisherAsync(PublisherDto model);
        Task<IEnumerable<PublisherVM>> GetAllAsync();
        Task<int> UpdatePublisherAsync(int id, PublisherDto model);
        Task<int> DeleteAsync(int id);
        Task<PublisherVM> GetByIdAsync(int id);
    }
}
