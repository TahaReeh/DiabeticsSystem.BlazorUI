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

        public string Title { get; set; } = "Customers";

        public PaginationState pagination = new() { ItemsPerPage = 10 };

        public bool loading = false;

        public IQueryable<CustomerEntity>? Items;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
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
            Nav!.NavigateTo(AppRouter.Home);
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
