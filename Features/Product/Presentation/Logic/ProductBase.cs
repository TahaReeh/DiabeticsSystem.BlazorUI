using DiabeticsSystem.BlazorUI.Features.Product.Domain.Entitiy;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Product.Presentation.Logic
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        private HttpClient? Http { get; set; }

        public List<ProductListVM>? productListVMs;

        protected override async Task OnInitializedAsync()
        {
            productListVMs = await Http!.GetFromJsonAsync<List<ProductListVM>>("api/Product/GetAllProducts");
        }
    }
}
