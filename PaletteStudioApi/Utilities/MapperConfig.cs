using AutoMapper;
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
                .ForMember(p=>p.ColourGroups, x=>x.MapFrom(map=>map.ColourGroups));

            CreateMap<Colour, ColourDto>().ReverseMap()
                .ForMember(cg => cg.HexCode, c => c.MapFrom(map => map.HexCode.ToUpper()));


            //CreateMap<Colour, ColourReadOnlyDto>()
            //    .ForMember(c => c.Popularity, p => p.MapFrom(map => map.ColourGroups.Count)).ReverseMap();
            //CreateMap<Colour, ColourCreateDto>().ReverseMap();
            //CreateMap<Colour, ColourUpdateDto>().ReverseMap();

            CreateMap<ColourGroup, ColourGroupReadOnlyDto>().ReverseMap();
            CreateMap<ColourGroup, ColourGroupCreateDto>().ReverseMap()
                .ForMember(cg => cg.BackgroundColourHexCode, c => c.MapFrom(map => map.BackgroundColourHexCode.ToUpper()));

            CreateMap<ColourGroup, ColourGroupUpdateDto>().ReverseMap()
                .ForMember(cg => cg.BackgroundColourHexCode, c => c.MapFrom(map => map.BackgroundColourHexCode.ToUpper()))
                .ForMember(p => p.ForegroundColours, x => x.MapFrom(map => map.ForegroundColours)); 

            CreateMap<ForegroundColour, ForegroundColourReadOnlyDto>().ReverseMap();
            CreateMap<ForegroundColour, ForegroundColourCreateDto>().ReverseMap()
                .ForMember(cg => cg.ColourHexCode, c => c.MapFrom(map => map.ColourHexCode.ToUpper()));

            CreateMap<ForegroundColour, ForegroundColourUpdateDto>().ReverseMap()
                .ForMember(cg => cg.ColourHexCode, c => c.MapFrom(map => map.ColourHexCode.ToUpper()));



            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
