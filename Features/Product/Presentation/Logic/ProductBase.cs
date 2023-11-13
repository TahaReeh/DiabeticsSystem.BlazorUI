using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;

namespace DiabeticsSystem.BlazorUI.Features.Product.Presentation.Logic
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        private IProductUsecase Usecase { get; set; } = default!;

        [Inject]
        private NavigationManager Nav { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        public string Title { get; set; } = "Products";

        public PaginationState pagination = new() { ItemsPerPage = 7 };

        public bool loading = false;

        public bool Overlay = false;

        public IQueryable<ProductEntity>? Items;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Overlay = true;
            await FetchItemsAsync();
            Overlay = false;
        }

        public async Task FetchItemsAsync()
        {
            Items = await Usecase.GetAllProduct();
        }
        public IQueryable<ProductEntity>? Filtereditems =>
            Items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

        public void HandleNameFilter(ChangeEventArgs args)
        {
            if (args.Value is string value)
            {
                nameFilter = value;
            }
        }
        public void HandleClear()
        {
            if (string.IsNullOrWhiteSpace(nameFilter))
            {
                nameFilter = string.Empty;
            }
        }

        public void OnCreateClick()
        {
            Nav!.NavigateTo(AppRouter.ProductsUpsert);
        }

        public async Task OnDeleteClick(Guid id)
        {
            var result = await AppDialogs.MessageBoxDelete("Product", DialogService);

            if (!result.Cancelled)
            {
                await Usecase.RemoveProduct(id);
                await FetchItemsAsync();
                AppToast.ShowSuccessToast("Product deleted", ToastService);
            }
        }

        public void OnEditClick(Guid? ProductId)
        {
            Nav!.NavigateTo($"{AppRouter.ProductsUpsert}{ProductId}");
        }
    }
}
