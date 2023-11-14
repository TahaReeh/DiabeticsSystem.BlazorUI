using AutoMapper;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;
using System.Linq;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase
{
    public interface IPatientMovementUsecase
    {
        Task<IQueryable<PatientMovementModel>> GetAllPatientMovement();
        Task<PatientMovementModel> GetPatientMovement(Guid? id);
        Task<string> AddPatientMovement(PatientMovementModel product);
        Task RemovePatientMovement(Guid? id);
    }

    public class PatientMovementUsecase : IPatientMovementUsecase
    {
        private readonly IUnitOfWork unitOfWork;

        public PatientMovementUsecase(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<IQueryable<PatientMovementModel>> GetAllPatientMovement()
        {
            var request = await unitOfWork.PatientMovementRepository.GetAllAsync(EndPoints.GetAllPatientMovement);
            var dto = request.AsQueryable();
            return dto;
        }

        public Task<PatientMovementModel> GetPatientMovement(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<string> AddPatientMovement(PatientMovementModel product)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePatientMovement(Guid? id)
        {
            await unitOfWork.PatientMovementRepository.RemoveAsync(EndPoints.RemovePatientMovement, id);
        }
    }
}
