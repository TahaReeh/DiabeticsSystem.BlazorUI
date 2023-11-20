using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Presentation.Componant;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Presentation.Logic
{
    public class PatientMovementBase : ComponentBase
    {
        [Inject]
        private IPatientMovementUsecase Usecase { get; set; } = default!;

        [Inject]
        private IToastService ToastService { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

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
        public async Task OnCreateClick()
        {
            var dialog = await DialogService.ShowDialogAsync<CreateRecordDialog>(new DialogParameters()
            {
                Height = "240px",
                Title = $"Create new record",
                PreventDismissOnOverlayClick = true,
                PreventScroll = true,
            });
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await FetchItemsAsync();
                AppToast.ShowSuccessToast("Record created", ToastService);
            }
        }

        public async Task OnBtnExportCsvClick()
        {
            var result = await AppDialogs.MessageBoxConfirm("Patient Movement CSV", "Export", DialogService);
            if (!result.Cancelled)
            {
                var fileData = await Usecase.GetPatientMovmentsCSV();
                if (fileData != null)
                {
                    var fileName = $"Diabetics{DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)}.csv";

                    await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileData));

                    AppToast.ShowSuccessToast("CSV File Exproted", ToastService);
                }
            }
        }
        public async Task OnBtnExportPdfClick()
        {
            var result = await AppDialogs.MessageBoxConfirm("Patient Movement PDF", "Export", DialogService);
            if (!result.Cancelled)
            {
                var fileData = await Usecase.GetPatientMovmentsPDF();
                if (fileData != null)
                {
                    var fileName = $"Diabetics{DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)}.csv";

                    await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileData));

                    AppToast.ShowSuccessToast("PDF File Exproted", ToastService);
                }
            }
        }
    }
}
