using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Entity;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Contract
{
    public interface IPatientMovementRepository : IRepository<PatientMovementModel>
    {
        Task<IEnumerable<PatientMovementModel>> GetPatientByCustomer(string route, Guid? id);
        Task<string> AddTest(string route, CreatePatientMovementEntity entity);
        Task<byte[]> GetPatientMovmentsCSV(string route);
        Task<byte[]> GetAllPatientsMovmentPDF(string route);
        Task<byte[]> GetPatientMovementByCustomerToPDF(string route,Guid id);
    }
}
