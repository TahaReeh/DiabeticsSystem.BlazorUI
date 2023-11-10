﻿using DiabeticsSystem.BlazorUI.Core.Constants;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Product.Presentation.Logic
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        private IProductUsecase Usecase { get; set; } = default!;
        [Inject]
        private NavigationManager? Nav { get; set; }

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        public string Title { get; set; } = "Products";

        public PaginationState pagination = new() { ItemsPerPage = 10 };

        public bool loading = false;

        public IQueryable<ProductEntity>? Items;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
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

        public void OnDeleteClick(Guid id)
        {
            ShowToast($"ID: {id}");
        }

        void ShowToast(string message)
        {
            ToastService.ShowToast(
                ToastIntent.Success,
                message
            );
        }
    }
}
