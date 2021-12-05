using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProviderDto, Provider>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
