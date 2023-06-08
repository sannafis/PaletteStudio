using AutoMapper;
using Blazored.LocalStorage;
using PaletteStudioClient.Models;
using PaletteStudioClient.Models.Paging;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PaletteStudioClient.Service.Palette
{
    public class PaletteService : BaseService, IPaletteService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly IMapper _mapper;

        public PaletteService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            this._client = client;
            this._localStorage = localStorage;
            this._mapper = mapper;
        }

        public async Task<Response<int>> CreatePalette(PaletteCreateDto palette)
        {
            Response<int> response = new Response<int> { Success = true };
            try
            {
                await GetToken();
                var newPalette = await _client.PalettePOSTAsync(palette);
                response = new Response<int> { Data = newPalette.Id, Success = true };
            }
            catch (ApiException ex)
            {
                response = ConvertApiException<int>(ex);
            }

            return response;
        }

        public async Task<Response<PaletteReadOnlyDto>> GetPalette(int id)
        {
            Response<PaletteReadOnlyDto> response;
            try
            {
                await GetToken();
                var palette = await _client.PaletteGETAsync(id);
                response = new Response<PaletteReadOnlyDto>
                {
                    Data = palette,
                    Success = true
                };
            }
            catch (ApiException ex)
            {

                response = ConvertApiException<PaletteReadOnlyDto>(ex);

            }
            return response;
        }

        public async Task<Response<PagedData<PaletteReadOnlyDto>>> GetPalettes(PagingParameters pagingParams)
        {
            Response<PagedData<PaletteReadOnlyDto>> response;
            try
            {
                await GetToken();
                var palettes = await _client.PalettesGETAsync(pagingParams.PageNumber, pagingParams.PageSize);
                response = new Response<PagedData<PaletteReadOnlyDto>>
                {
                    Data = palettes,
                    Success = true
                };
            }
            catch (ApiException ex)
            {

                response = ConvertApiException<PagedData<PaletteReadOnlyDto>>(ex);

            }
            return response;
        }

        public async Task<Response<bool>> UpdatePalette(int id, PaletteReadOnlyDto palette)
        {
            Response<bool> response;
            try
            {
                await GetToken();
                await _client.PalettePUTAsync(id, _mapper.Map<PaletteUpdateDto>(palette));
                response = new Response<bool>
                {
                    Data = true,
                    Success = true
                };
            }
            catch (ApiException ex)
            {

                response = ConvertApiException<bool>(ex);

            }
            return response;
        }
    }
}
