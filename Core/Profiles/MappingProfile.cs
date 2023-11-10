using AutoMapper;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Data.ViewModels;

namespace DiabeticsSystem.BlazorUI.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductEntity, ProductVM>();
        }

    }
}
