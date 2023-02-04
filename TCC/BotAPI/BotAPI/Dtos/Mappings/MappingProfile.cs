using AutoMapper;
using BotAPI.Models;

namespace BotAPI.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
