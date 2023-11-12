using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Product.Presentation.Logic
{
    public class ProductUpdesrtBase : ComponentBase
    {
        [Inject]
        private IProductUsecase Usecase { get; set; } = default!;

        [Inject]
        private NavigationManager Nav { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Parameter]
        public Guid? ProductId { get; set; }

        public ProductModel? ProductDetail;

        public int MaxNumber { get; set; }

        public string Title { get; set; } = string.Empty;

        async Task GetMaxNumber()
        {
            var obj = await Usecase.GetAllProduct();
            MaxNumber = obj.Max(x => Convert.ToInt32(x.Number )) + 1;
        }

        protected override async Task OnParametersSetAsync()
        {
            ProductDetail = new()
            {
                Name = string.Empty,
                Details = string.Empty,
                Code = string.Empty,
                Company = string.Empty,
            };

            if (ProductId is null)
            {
                Title = "Create Product";
                await GetMaxNumber();
            }
            else
            {
                ProductModel productObj = await Usecase.GetProductDetail(ProductId.Value);
                ProductDetail = new()
                {
                    Id = productObj.Id,
                    Number = productObj.Number,
                    Name = productObj.Name,
                    Details = productObj.Details,
                    Code = productObj.Code,
                    Company = productObj.Company,
                };
                Title = $"Edit {ProductDetail.Name}";
                MaxNumber = Convert.ToInt32(ProductDetail.Number);
            }
        }

        public void OnCancelClick()
        {
            Nav.NavigateTo(AppRouter.Products);
        }

        public async Task HandleValidSubmit()
        {
            if (ProductDetail!.Id == Guid.Empty)
            {
                ProductDetail.Number = MaxNumber.ToString();
               var newId = await Usecase.AddProduct(ProductDetail);
                if (newId != string.Empty)
                {
                   ToastService.ShowToast(
                     ToastIntent.Success,
                    "Product created successfuly");
                    ProductDetail = new()
                    {
                        Name = string.Empty,
                        Details = string.Empty,
                        Code = string.Empty,
                        Company = string.Empty,
                    };
                    await GetMaxNumber();
                }
                else
                {
                    ToastService.ShowToast(
                     ToastIntent.Error,
                    "Somthing went wrong!");
                }
            }
            else
            {
                await Usecase.UpdateProduct(ProductDetail);
                Nav.NavigateTo(AppRouter.Products);
                ToastService.ShowToast(
                   ToastIntent.Success,
                  "Product updated successfuly");
            }

        }
    }
}
