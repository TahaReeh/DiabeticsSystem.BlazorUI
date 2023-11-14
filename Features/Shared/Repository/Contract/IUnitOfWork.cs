using DiabeticsSystem.BlazorUI.Features.Customer.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Repository;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IPatientMovementRepository PatientMovementRepository { get; }
    }
}
