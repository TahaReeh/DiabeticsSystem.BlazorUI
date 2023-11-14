using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Presentation.Logic
{
    public class PatientMovementBase : ComponentBase
    {
        [Inject]
        private IPatientMovementUsecase Usecase { get; set; } = default!;

        [Inject]
        private NavigationManager Nav { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        public string Title { get; set; } = "Patient Movement";

        public PaginationState pagination = new() { ItemsPerPage = 7 };

        public bool loading = false;

        public bool Overlay = false;

        public IQueryable<PatientMovementModel>? Items;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Overlay = true;
            await FetchItemsAsync();
            Overlay = false;
        }

        public async Task FetchItemsAsync()
        {
            Items = await Usecase.GetAllPatientMovement();
            
        }
        public IQueryable<PatientMovementModel>? Filtereditems =>
            Items?.Where(x => x.Customer.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

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
            //Nav!.NavigateTo(AppRouter.ProductsUpsert);
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
