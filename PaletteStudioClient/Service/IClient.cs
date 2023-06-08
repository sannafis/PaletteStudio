using PaletteStudioClient.Models;
using PaletteStudioClient.Models.Authentication;
using PaletteStudioClient.Models.Paging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PaletteStudioClient.Service
{
    public interface IClient
    {
        public HttpClient HttpClient { get; }

        Task RegisterAsync(UserDto body);
        Task RegisterAsync(UserDto body, CancellationToken cancellationToken);

        Task<AuthResponse> LoginAsync(UserLoginDto body);
        Task<AuthResponse> LoginAsync(UserLoginDto body, CancellationToken cancellationToken);

        Task<PagedData<PaletteReadOnlyDto>> PalettesGETAsync(int? startIndex, int? pageSize);
        Task<PagedData<PaletteReadOnlyDto>> PalettesGETAsync(int? startIndex, int? pageSize, CancellationToken cancellationToken);

        Task<PaletteReadOnlyDto> PaletteGETAsync(int? id);
        Task<PaletteReadOnlyDto> PaletteGETAsync(int? id, CancellationToken cancellationToken);

        Task<PagedData<PaletteReadOnlyDto>> PalettesGETPublicAsync(int? startIndex, int? pageSize);
        Task<PagedData<PaletteReadOnlyDto>> PalettesGETPublicAsync(int? startIndex, int? pageSize, CancellationToken cancellationToken);

        Task<PaletteReadOnlyDto> PalettePOSTAsync(PaletteCreateDto body);
        Task<PaletteReadOnlyDto> PalettePOSTAsync(PaletteCreateDto body, CancellationToken cancellationToken);

        Task PalettePUTAsync(int id, PaletteUpdateDto body);
        Task PalettePUTAsync(int id, PaletteUpdateDto body, CancellationToken cancellationToken);

        Task PaletteDELETEAsync(int id);
        Task PaletteDELETEAsync(int id, CancellationToken cancellationToken);
    }
}
