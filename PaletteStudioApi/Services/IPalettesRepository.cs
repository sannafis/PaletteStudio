using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Services
{

    public interface IPalettesRepository : IGenericRepository<Palette>
    {
        Task<PaletteReadOnlyDto> GetIncludeColours(int id, string userId);
        Task<List<PaletteReadOnlyDto>> GetAllIncludeColours();
        Task<PagedData<PaletteReadOnlyDto>> GetAllPagedIncludeColours(PagingParameters pagingParameters);
        Task UpdateFullAsync(int id, PaletteUpdateDto paletteUpdateDto);
    }
}
