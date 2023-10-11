using AutoMapper;
using MagicVilla_web.Models.Dto.Villa;
using MagicVilla_web.Models.Dto.VillaNumber;

namespace MagicVilla_web
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumberDto, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();


        }
    }
}
