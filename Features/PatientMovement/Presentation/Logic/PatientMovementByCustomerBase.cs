using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Presentation.Componant;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Presentation.Logic
{
    public class PatientMovementByCustomerBase : FluentComponentBase
    {
        [Inject]
        private IPatientMovementUsecase Usecase { get; set; } = default!;

        [Inject]
        private ICustomerUsecase CustomerUsecase { get; set; } = default!;

        [Inject]
        private IToastService ToastService { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        public string Title { get; set; } = "Patient Movement";

        public PaginationState pagination = new() { ItemsPerPage = 7 };

        public bool loading = false;

        public bool Overlay = false;

        public IQueryable<PatientMovementModel>? Items { get; set; }

        public IQueryable<CustomerEntity>? CustomersList { get; set; }

        public CustomerEntity? SelectedCustomer { get; set; }
        public string SelectedValue { get; set; } = string.Empty;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await FetchCustomersAsync();
        }
        public async Task FetchCustomersAsync()
        {
            CustomersList = await CustomerUsecase.GetAllCustomer();
        }

        public async Task FetchItemsAsync()
        {
            if (SelectedCustomer is not null)
            {
                try
                {
                    Overlay = true;
                    Items = await Usecase.GetPatientMovementByCustomer(SelectedCustomer?.Id);
                    Overlay = false;
                }
                catch (Exception e)
                {
                    Overlay = false;
                    AppToast.ShowCustomErrorToast(e.Message, ToastService);
                }
            }
            else
            {
                Items = Enumerable.Empty<PatientMovementModel>().AsQueryable();
            }
        }
        public IQueryable<PatientMovementModel>? Filtereditems =>
            Items?.Where(x => x.CreatedDate.ToString().Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

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

        public async Task OnDeleteClick(Guid id)
        {
            var result = await AppDialogs.MessageBoxDelete("Patient Movement", DialogService);

            if (!result.Cancelled)
            {
                await Usecase.RemovePatientMovement(id);
                await FetchItemsAsync();
                AppToast.ShowSuccessToast("Movement deleted", ToastService);
            }
        }
    }
}
