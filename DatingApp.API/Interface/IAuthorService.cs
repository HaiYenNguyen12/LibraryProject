using DatingApp.API.DTOs;
using DatingApp.API.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.API.Interface
{
    public interface IAuthorService
    {
        Task<int> AddAuthorAsync(AuthorDto model);
        Task<IEnumerable<AuthorVM>> GetAllAsync();
        Task<int> UpdateAuthorAsync(int id, AuthorDto model);
        Task<int> DeleteAuthorAsync(int id);
        Task<AuthorVM> GetByIdAsync(int id);
    }
}
