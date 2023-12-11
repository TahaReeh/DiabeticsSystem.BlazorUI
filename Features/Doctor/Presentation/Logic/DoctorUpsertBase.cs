using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Doctor.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Doctor.Domain.Usecase;

namespace DiabeticsSystem.BlazorUI.Features.Doctor.Presentation.Logic
{
    public class DoctorUpsertBase : ComponentBase
    {
        [Inject]
        private IDoctorUsecase Usecase { get; set; } = default!;

        [Inject]
        private NavigationManager Nav { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Parameter]
        public Guid? DoctorId { get; set; }

        public DoctorModel? DoctorDetail;

        public int MaxNumber { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? FluentSelectIntValue { get; set; } = string.Empty;

        public bool loading = false;

        async Task GetMaxNumber()
        {
            var obj = await Usecase.GetAllDoctors();
            MaxNumber = obj.Max(x => Convert.ToInt32(x.Number)) + 1;
        }

        protected override async Task OnParametersSetAsync()
        {
            DoctorDetail = new()
            {
                Name = string.Empty,
                Phone = string.Empty,
                BirthDate = DateTime.Now,
            };

            if (DoctorId is null)
            {
                Title = "Create Doctor";
                await GetMaxNumber();
            }
            else
            {
                DoctorModel doctorObj = await Usecase.GetDoctorDetail(DoctorId.Value);
                DoctorDetail = new()
                {
                    Id = doctorObj.Id,
                    Number = doctorObj.Number,
                    Name = doctorObj.Name,
                    Phone = doctorObj.Phone,
                    SecondPhone = doctorObj.SecondPhone,
                    Email = doctorObj.Email,
                    Address = doctorObj.Address,
                    PersonalId = doctorObj.PersonalId,
                    BirthDate = doctorObj.BirthDate,
                    Sex = doctorObj.Sex

                };
                FluentSelectIntValue = doctorObj.Sex.ToString();
                Title = $"Edit {DoctorDetail.Name}";
                MaxNumber = Convert.ToInt32(DoctorDetail.Number);
            }
        }

        public void OnCancelClick()
        {
            Nav.NavigateTo(AppRouter.Doctor);
        }

        public async Task HandleValidSubmit()
        {
            try
            {
                loading = true;
                DoctorDetail!.Sex = string.IsNullOrEmpty(FluentSelectIntValue)
                    ? 1 : Convert.ToInt32(FluentSelectIntValue);
                if (DoctorDetail.Id == Guid.Empty)
                {
                    DoctorDetail.Number = MaxNumber.ToString();
                    var newId = await Usecase.AddDoctor(DoctorDetail);
                    if (newId != string.Empty)
                    {
                        AppToast.ShowSuccessToast("Doctor created", ToastService);

                        DoctorDetail = new()
                        {
                            Name = string.Empty,
                            Phone = string.Empty,
                            BirthDate = DateTime.Now,
                        };
                        await GetMaxNumber();
                    }
                    else
                    {
                        AppToast.ShowErrorToast(ToastService);
                    }
                }
                else
                {
                    await Usecase.UpdateDoctor(DoctorDetail);
                    Nav.NavigateTo(AppRouter.Doctor);
                    AppToast.ShowSuccessToast("Doctor updated", ToastService);
                }
                loading = false;
            }
            catch (Exception e)
            {
                AppToast.ShowCustomErrorToast(e.Message, ToastService);
                loading = false;
            }
        }
    }
}
