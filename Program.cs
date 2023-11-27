using DiabeticsSystem.BlazorUI.Core.Services;
using DiabeticsSystem.BlazorUI.Features.Customer.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Home.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.PatientMovement.Domain.Usecase;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Usecase;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddFluentUIComponents(options =>
{
    options.HostingModel = BlazorHostingModel.WebAssembly;
});

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:86/api/") //localhost:5172/
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICookie, Cookie>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IProductUsecase, ProductUsecase>();
builder.Services.AddScoped<ICustomerUsecase, CustomerUsecase>();
builder.Services.AddScoped<IPatientMovementUsecase, PatientMovementUsecase>();
builder.Services.AddScoped<IHomeUsecase, HomeUsecase>();

await builder.Build().RunAsync();
