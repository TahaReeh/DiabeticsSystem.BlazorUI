using DiabeticsSystem.BlazorUI.Features.Customer.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Repository;
using DiabeticsSystem.BlazorUI.Features.Doctor.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Repository;
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
        private readonly Dictionary<Type, object> _repositories;
        public IProductRepository ProductRepository { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IPatientMovementRepository PatientMovementRepository { get; private set; }
        public IHomeRepository HomeRepository { get; private set; }
        public IDoctorRepository DoctorRepository { get; private set; }

        public UnitOfWork(HttpClient http)
        {
            Http = http;
            _repositories = [];
            ProductRepository = new ProductRepository(Http);
            CustomerRepository = new CustomerRepository(Http);
            PatientMovementRepository = new PatientMovementRepository(Http);
            HomeRepository = new HomeRepository(Http);
            DoctorRepository = new DoctorRepository(Http);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
                return (_repositories[typeof(T)] as IRepository<T>)!;

            var repository = new Repository<T>(Http);
            _repositories.Add(typeof(T), repository);
            return repository;
        }
    }
}
