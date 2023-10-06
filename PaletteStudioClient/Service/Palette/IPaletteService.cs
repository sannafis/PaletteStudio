using PaletteStudioClient.Models;
using PaletteStudioClient.Models.Paging;
using System.Threading.Tasks;

namespace PaletteStudioClient.Service.Palette
{
    public interface IPaletteService
    {
        public Task<Response<PagedData<PaletteReadOnlyDto>>> GetPalettes(PagingParameters pagingParams);
        public Task<Response<PaletteReadOnlyDto>> GetPalette(int id);
        public Task<Response<int>> CreatePalette(PaletteCreateDto palette);
        public Task<Response<bool>> UpdatePalette(int id, PaletteReadOnlyDto palette);
    }
}
