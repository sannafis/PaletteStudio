using AutoMapper;
using PaletteStudioClient.Models;

namespace PaletteStudioClient.Utilities
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<PaletteUpdateDto, PaletteReadOnlyDto>().ReverseMap();
        }
    }
}
