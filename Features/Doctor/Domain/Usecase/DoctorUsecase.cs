using DiabeticsSystem.BlazorUI.Core.Profiles;
using DiabeticsSystem.BlazorUI.Features.Doctor.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Entity;

namespace DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Usecase
{
    public interface IDoctorUsecase
    {
        Task<IQueryable<DoctorEntity>> GetAllDoctors();
        Task<DoctorModel> GetDoctorDetail(Guid? id);
        Task<string> AddDoctor(DoctorModel entity);
        Task RemoveDoctor(Guid? id);
        Task UpdateDoctor(DoctorModel entity);
    }
    public class DoctorUsecase : IDoctorUsecase
    {
        private readonly IUnitOfWork unitOfWork;

        public DoctorUsecase(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<string> AddDoctor(DoctorModel entity)
        {
            return await unitOfWork.DoctorRepository.AddAsync(EndPoints.AddDoctor, entity);
        }

        public async Task<IQueryable<DoctorEntity>> GetAllDoctors()
        {
            var request = await unitOfWork.DoctorRepository.GetAllAsync(EndPoints.GetAllDoctors);
            var dto = request.Select(x => x.MapDoctorFromModel());
            return dto.AsQueryable();
        }

        public async Task<DoctorModel> GetDoctorDetail(Guid? id) =>
            await unitOfWork.DoctorRepository.GetAsync(EndPoints.GetDoctor, id);

        public async Task RemoveDoctor(Guid? id)
        {
            await unitOfWork.DoctorRepository.RemoveAsync(EndPoints.RemoveDoctor, id);
        }

        public async Task UpdateDoctor(DoctorModel entity)
        {
            await unitOfWork.DoctorRepository.UpdateAsync(EndPoints.UpdateDoctor, entity);
        }
    }
}
