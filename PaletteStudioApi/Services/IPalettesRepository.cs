using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Paging;

namespace PaletteStudioApi.Services
{

    public interface IPalettesRepository
    {
        Task<PaletteReadOnlyDto> CreateAsync(PaletteCreateDto paletteDto);

        Task<PaletteReadOnlyDto> GetIncludeColoursAsync(int id);

        Task<List<PaletteReadOnlyDto>> GetAllIncludeColoursAsync();

        Task<List<PaletteReadOnlyDto>> PublicGetAllAsync();

        Task<PagedData<PaletteReadOnlyDto>> GetAllPagedIncludeColoursAsync(PagingParameters pagingParameters);

        Task<PagedData<PaletteReadOnlyDto>> PublicGetAllPagedAsync(PagingParameters pagingParameters);

        Task UpdateFullAsync(int id, PaletteUpdateDto paletteUpdateDto);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);
    }
}
