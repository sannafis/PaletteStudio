using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Contracts
{

    public interface IPalettesRepository : IGenericRepository<Palette>
    {
        Task<PaletteReadOnlyDto> GetIncludeColours(int id);
        Task<List<PaletteReadOnlyDto>> GetAllIncludeColours();
        Task<PagedData<PaletteReadOnlyDto>> GetAllPagedIncludeColours(PagingParameters pagingParameters);
        Task UpdateFullAsync(int id, PaletteUpdateDto paletteUpdateDto);
    }
}
