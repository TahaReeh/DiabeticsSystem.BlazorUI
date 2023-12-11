using DiabeticsSystem.BlazorUI.Features.Customer.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Doctor.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Home.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Repository;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository.Contract
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IPatientMovementRepository PatientMovementRepository { get; }
        IHomeRepository HomeRepository { get; }
        IDoctorRepository DoctorRepository { get; }
    }
}
