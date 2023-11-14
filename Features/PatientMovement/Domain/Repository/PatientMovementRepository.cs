using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Contract;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Repository
{
    public class PatientMovementRepository : Repository<PatientMovementModel>, IPatientMovementRepository
    {
        public PatientMovementRepository(HttpClient http) : base(http)
        {
        }
    }
}
