using AutoMapper;
using Cl = ColourLibrary;
using PaletteStudioApi.Models;
using PaletteStudioApi.Models.Authentication;

namespace PaletteStudioApi.Utilities
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Palette, PaletteReadOnlyDto>().ReverseMap();
            CreateMap<Palette, PaletteCreateDto>().ReverseMap();
            CreateMap<Palette, PaletteUpdateDto>().ReverseMap()
                .ForMember(p => p.ColourGroups, x => x.MapFrom(map => map.ColourGroups));

            CreateMap<Models.Colour, ColourDto>().ReverseMap()
                .ForMember(cg => cg.HexCode, c => c.MapFrom(map => map.HexCode.ToUpper()));

            CreateMap<ColourGroup, ColourGroupReadOnlyDto>().ReverseMap();
            CreateMap<ColourGroup, ColourGroupCreateDto>().ReverseMap()
                .ForMember(cg => cg.BackgroundColourHexCode, x => x.MapFrom(map => map.BackgroundColourHexCode.ToUpper()));

            CreateMap<ColourGroup, ColourGroupUpdateDto>().ReverseMap()
                .ForMember(cg => cg.BackgroundColourHexCode, x => x.MapFrom(map => map.BackgroundColourHexCode.ToUpper()))
                .ForMember(cg => cg.ForegroundColours, x => x.MapFrom(map => map.ForegroundColours));

            CreateMap<ForegroundColour, ForegroundColourReadOnlyDto>()
                .ForMember(f => f.Contrast, x => x.MapFrom(map => Cl.Colour.ContrastRatio(map.ColourHexCode, map.ColourGroup!.BackgroundColourHexCode)))
                .ForMember(f => f.RegularTextRating, x => x.MapFrom(map => Cl.Colour.RegularTextRating(Cl.Colour.ContrastRatio(map.ColourHexCode, map.ColourGroup!.BackgroundColourHexCode))))
                .ForMember(f => f.LargeTextRating, x => x.MapFrom(map => Cl.Colour.LargeTextRating(Cl.Colour.ContrastRatio(map.ColourHexCode, map.ColourGroup!.BackgroundColourHexCode))))
                .ReverseMap();

            CreateMap<ForegroundColour, ForegroundColourCreateDto>().ReverseMap()
                .ForMember(f => f.ColourHexCode, x => x.MapFrom(map => map.ColourHexCode.ToUpper()));

            CreateMap<ForegroundColour, ForegroundColourUpdateDto>().ReverseMap()
                .ForMember(f => f.ColourHexCode, x => x.MapFrom(map => map.ColourHexCode.ToUpper()));

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
