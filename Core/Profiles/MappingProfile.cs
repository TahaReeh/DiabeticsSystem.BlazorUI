using AutoMapper;
using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;

namespace DiabeticsSystem.BlazorUI.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<CustomerModel, CustomerEntity>();
        }

    }
}
