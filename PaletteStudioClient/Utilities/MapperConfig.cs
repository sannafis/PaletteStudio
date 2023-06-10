using AutoMapper;
using PaletteStudioClient.Models;
using PaletteStudioClient.Models.Authentication;

namespace PaletteStudioClient.Utilities
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<PaletteUpdateDto, PaletteReadOnlyDto>().ReverseMap();
            CreateMap<ColourGroupUpdateDto, ColourGroupReadOnlyDto>().ReverseMap();
            CreateMap<ForegroundColourUpdateDto, ForegroundColourReadOnlyDto>().ReverseMap();
        }
    }
}
