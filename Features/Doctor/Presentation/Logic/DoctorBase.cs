using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Usecase;

namespace DiabeticsSystem.BlazorUI.Features.Doctor.Presentation.Logic
{
    public class DoctorBase : ComponentBase
    {
        [Inject]
        private IDoctorUsecase Usecase { get; set; } = default!;
        [Inject]
        private NavigationManager Nav { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        public string Title { get; set; } = "Doctors";

        public PaginationState pagination = new() { ItemsPerPage = 7 };

        public bool loading = false;

        public bool Overlay = false;

        public IQueryable<DoctorEntity>? Items;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Overlay = true;
            await FetchItemsAsync();
            Overlay = false;
        }

        public async Task FetchItemsAsync()
        {
            Items = await Usecase.GetAllDoctors();
        }

        public IQueryable<DoctorEntity>? Filtereditems =>
            Items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase)
            ).OrderBy(x => Convert.ToInt32(x.Number));

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
            Nav!.NavigateTo(AppRouter.DoctorUpsert);
        }

        public async Task OnDeleteClick(Guid id)
        {
            var result = await AppDialogs.MessageBoxDelete("Doctor", DialogService);

            if (!result.Cancelled)
            {
                await Usecase.RemoveDoctor(id);
                await FetchItemsAsync();
                AppToast.ShowSuccessToast("Doctor deleted", ToastService);
            }
        }

        public void OnEditClick(Guid? CustomerId)
        {
            Nav!.NavigateTo($"{AppRouter.DoctorUpsert}{CustomerId}");
        }
    }
}
