using AutoMapper;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Data.Model;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Entity;
using DiabeticsSystem.BlazorUI.Features.Product.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.ViewModels;
using Microsoft.Fast.Components.FluentUI.DesignTokens;
using System.Linq;

namespace DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase
{
    public interface IPatientMovementUsecase
    {
        Task<IQueryable<PatientMovementModel>> GetAllPatientMovement();
        Task<IQueryable<PatientMovementModel>> GetPatientMovementByCustomer(Guid? id);
        Task<string> AddPatientMovement(CreatePatientMovementEntity entity);
        Task RemovePatientMovement(Guid? id);
        Task<byte[]> GetPatientMovmentsCSV();
    }

    public class PatientMovementUsecase(IUnitOfWork _unitOfWork) : IPatientMovementUsecase
    {
        private readonly IUnitOfWork unitOfWork = _unitOfWork;

        public async Task<IQueryable<PatientMovementModel>> GetAllPatientMovement()
        {
            var request = await unitOfWork.PatientMovementRepository.GetAllAsync(EndPoints.GetAllPatientMovement);
            var dto = request.AsQueryable();
            return dto;
        }

        public async Task<IQueryable<PatientMovementModel>> GetPatientMovementByCustomer(Guid? id)
        {
            var request = await unitOfWork.PatientMovementRepository.GetPatientByCustomer(EndPoints.GetPatientMovement, id);
            var dto = request.AsQueryable();
            return dto;
        }

        public async Task<string> AddPatientMovement(CreatePatientMovementEntity entity)
        {
            return await unitOfWork.PatientMovementRepository.AddTest(EndPoints.AddPatientMovement, entity);
        }

        public async Task RemovePatientMovement(Guid? id)
        {
            await unitOfWork.PatientMovementRepository.RemoveAsync(EndPoints.RemovePatientMovement, id);
        }

        public async Task<byte[]> GetPatientMovmentsCSV()
        {
            return await unitOfWork.PatientMovementRepository.GetPatientMovmentsCSV(EndPoints.ExportAllPatientMovments);
        }


    }
}
