using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<FakeStoreDto, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => new Money(src.Price, "USD")))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Id, opt => opt.Ignore());


        }
    }
}
