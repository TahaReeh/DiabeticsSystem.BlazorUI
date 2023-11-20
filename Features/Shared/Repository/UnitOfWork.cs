using DiabeticsSystem.BlazorUI.Features.Customer.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Repository;
using DiabeticsSystem.BlazorUI.Features.Home.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Home.Domain.Repository;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Repository;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Repository;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Repository;

namespace DiabeticsSystem.BlazorUI.Features.Shared.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HttpClient Http;
        public IProductRepository ProductRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IPatientMovementRepository PatientMovementRepository { get; private set; }
        public ISystemSettingRepository SystemSettingRepository { get; private set; }

        public UnitOfWork(HttpClient http)
        {
            Http = http;
            ProductRepository = new ProductRepository(Http);
            CustomerRepository = new CustomerRepository(Http);
            PatientMovementRepository = new PatientMovementRepository(Http);
            SystemSettingRepository = new SystemSettingRepository(Http);
        }
    }
}
