using Microsoft.EntityFrameworkCore;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Services
{
    public interface IColoursRepository
    {
        Task<PagedData<ColourDto>> GetAllPagedAsync(PagingParameters pagingParameters);
        Task<ColourDto> CreateNormalizedAsync(ColourDto colour);
        Task<ColourDto> GetAsync(string? hex);
        Task<List<ColourDto>> GetAllAsync();
        Task<Colour?> GetEntityAsync(string? hex);
        Task<bool> Exists(string hex);
        Task DeleteAsync(string hex);
    }
}
