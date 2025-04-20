using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Presentation.Logic
{
    public class CreateRecordDialogBase : ComponentBase
    {
        [Inject]
        private IPatientMovementUsecase Usecase { get; set; } = default!;

        [Inject]
        private ICustomerUsecase CustomerUsecase { get; set; } = default!;

        [Inject]
        private IProductUsecase ProductUsecase { get; set; } = default!;

        [Inject]
        private IDoctorUsecase DoctorUsecase { get; set; } = default!;

        public CustomerEntity? SelectedCustomer { get; set; }
        public ProductEntity? SelectedProduct { get; set; }
        public DoctorEntity? SelectedDoctor { get; set; }
        public string NewBarcode { get; set; } = string.Empty;
        public CreatePatientMovementEntity? NewRecord { get; set; }
        public IQueryable<CustomerEntity>? CustomersList { get; set; }
        public IQueryable<ProductEntity>? ProductList { get; set; }
        public IQueryable<DoctorEntity>? DoctorList { get; set; }

        public bool loading = false;

        protected override async Task OnInitializedAsync()
        {
            await FetchCreateRecordDialogAsync();
        }

        private async Task FetchCreateRecordDialogAsync()
        {
            CustomersList = await CustomerUsecase.GetAllCustomer();
            ProductList = await ProductUsecase.GetAllProduct();
            DoctorList = await DoctorUsecase.GetAllDoctors();
        }

        public async Task SaveDialog(FluentDialog Dialog)
        {
            if (SelectedCustomer is not null && SelectedProduct is not null
                && SelectedDoctor is not null && !string.IsNullOrEmpty(NewBarcode))
            {
                loading = true;
                NewRecord = new()
                {
                    CustomerId = SelectedCustomer.Id,
                    ProductId = SelectedProduct.Id,
                    DoctorId = SelectedDoctor.Id,
                    Barcode = NewBarcode
                };
                var newId = await Usecase.AddPatientMovement(NewRecord);
                if (newId != string.Empty)
                {
                    await Dialog.CloseAsync();
                }
                else
                {
                    await Dialog.CancelAsync();
                }
                loading = false;
            }
        }
    }
}
