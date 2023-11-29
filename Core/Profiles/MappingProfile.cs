using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;

namespace DiabeticsSystem.BlazorUI.Core.Profiles
{
    public static class MappingProfile
    {
        public static ProductEntity MapProductFromModel(this ProductModel model)
        {
            if (model != null)
            {
                return new ProductEntity
                {
                    Id = model.Id,
                    Number = model.Number,
                    Name = model.Name,
                    Details = model.Details,
                };
            }
            return new ProductEntity();
        }

        public static CustomerEntity MapCustomerFromModel(this CustomerModel model)
        {
            if (model != null)
            {
                return new CustomerEntity
                {
                    Id = model.Id,
                    Number = model.Number,
                    Name = model.Name,
                    Phone = model.Phone
                };
            }
            return new CustomerEntity();
        }
    }
}
