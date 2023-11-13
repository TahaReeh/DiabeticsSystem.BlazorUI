using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.Customer.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Customer.Presentation.Logic
{
    public class CustomerUpdesrtBase : ComponentBase
    {
        [Inject]
        private ICustomerUsecase Usecase { get; set; } = default!;

        [Inject]
        private NavigationManager Nav { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Parameter]
        public Guid? CustomerId { get; set; }

        public CustomerModel? CustomerDetail;

        public int MaxNumber { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? FluentSelectIntValue { get; set; } = string.Empty;

        async Task GetMaxNumber()
        {
            var obj = await Usecase.GetAllCustomer();
            MaxNumber = obj.Max(x => Convert.ToInt32(x.Number)) + 1;
        }

        protected override async Task OnParametersSetAsync()
        {
            CustomerDetail = new()
            {
                Name = string.Empty,
                Phone = string.Empty,
                BirthDate = DateTime.Now,
            };

            if (CustomerId is null)
            {
                Title = "Create Customer";
                await GetMaxNumber();
            }
            else
            {
                CustomerModel customerObj = await Usecase.GetCustomerDetail(CustomerId.Value);
                CustomerDetail = new()
                {
                    Id = customerObj.Id,
                    Number = customerObj.Number,
                    Name = customerObj.Name,
                    Phone = customerObj.Phone,
                    SecondPhone = customerObj.SecondPhone,
                    Email = customerObj.Email,
                    Address = customerObj.Address,
                    PersonalId = customerObj.PersonalId,
                    BirthDate = customerObj.BirthDate,
                    Sex = customerObj.Sex

                };
                FluentSelectIntValue = customerObj.Sex.ToString();
                Title = $"Edit {CustomerDetail.Name}";
                MaxNumber = Convert.ToInt32(CustomerDetail.Number);
            }
        }

        public void OnCancelClick()
        {
            Nav.NavigateTo(AppRouter.Customer);
        }

        public async Task HandleValidSubmit()
        {
            try
            {
                CustomerDetail!.Sex = string.IsNullOrEmpty(FluentSelectIntValue)
                    ? 1 : Convert.ToInt32(FluentSelectIntValue);
                if (CustomerDetail.Id == Guid.Empty)
                {
                    CustomerDetail.Number = MaxNumber.ToString();
                    var newId = await Usecase.AddCustomer(CustomerDetail);
                    if (newId != string.Empty)
                    {
                        AppToast.ShowSuccessToast("Customer created", ToastService);

                        CustomerDetail = new()
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
                    await Usecase.UpdateCustomer(CustomerDetail);
                    Nav.NavigateTo(AppRouter.Customer);
                    AppToast.ShowSuccessToast("Customer updated", ToastService);
                }
            }
            catch (Exception e)
            {
                AppToast.ShowCustomErrorToast(e.Message, ToastService);
            }
        }

    }
}
