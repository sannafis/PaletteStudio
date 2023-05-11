using PaletteStudioApi.Models;

namespace PaletteStudioApi.Contracts
{
    public interface IColoursRepository : IGenericRepository<Colour>
    {
        Task<ColourDto> CreateNormalizedAsync(ColourDto colour);
        Task<ColourDto> GetAsync(string? hex);
        Task<Colour?> GetEntityAsync(string? hex);
        Task<bool> Exists(string hex);
        Task DeleteAsync(string hex);
    }
}
