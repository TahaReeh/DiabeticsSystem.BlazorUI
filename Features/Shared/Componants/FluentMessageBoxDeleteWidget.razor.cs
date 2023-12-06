using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Componants
{
    public partial class FluentMessageBoxDeleteWidget
    {

        public bool loading = false;

        [CascadingParameter]
        public FluentDialog Dialog { get; set; } = default!;

        public void CloseDialog()
        {
            Dialog.CancelAsync();
        }

        public void ConfirmDialog()
        {
            Dialog.CloseAsync();
        }
    }
}
