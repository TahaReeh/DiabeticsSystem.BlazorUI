using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Presentation.Logic
{
    public class CustomerBase : ComponentBase
    {
        [Inject]
        private ICustomerUsecase Usecase { get; set; } = default!;
        [Inject]
        private NavigationManager? Nav { get; set; }

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        public string Title { get; set; } = "Customers";

        public PaginationState pagination = new() { ItemsPerPage = 7 };

        public bool loading = false;

        public bool Overlay = false;

        public IQueryable<CustomerEntity>? Items;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Overlay = true;
            await FetchItemsAsync();
            Overlay = false;
        }

        public async Task FetchItemsAsync()
        {
            Items = await Usecase.GetAllCustomer();
        }

        public IQueryable<CustomerEntity>? Filtereditems =>
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
            Nav!.NavigateTo(AppRouter.CustomerUpsert);
        }

        public async Task OnDeleteClick(Guid id)
        {
            var result = await AppDialogs.MessageBoxDelete("Customer", DialogService);

            if (!result.Cancelled)
            {
                await Usecase.RemoveCustomer(id);
                await FetchItemsAsync();
                AppToast.ShowSuccessToast("Customer deleted", ToastService);
            }
        }

        public void OnEditClick(Guid? CustomerId)
        {
            Nav!.NavigateTo($"{AppRouter.CustomerUpsert}{CustomerId}");
        }

    }
}
