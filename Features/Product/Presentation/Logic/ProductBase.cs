using DiabeticsSystem.BlazorUI.Features.Product.Domain.Entitiy;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Product.Presentation.Logic
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        private HttpClient? Http { get; set; }
        [Inject]
        private NavigationManager? Nav { get; set; }

        public bool loading = false;

        public List<ProductVM>? productList;

        protected override async Task OnInitializedAsync()
        {
            productList = await Http!.GetFromJsonAsync<List<ProductVM>>("api/Product/GetAllProducts");
        }

        public async Task OnCreateClick()
        {
            loading = true;
            await Task.Delay(2000);
            loading = false;
            Nav!.NavigateTo("/");
        }

        public async Task OnDeleteClick(string test)
        {
            loading = true;
            await Task.Delay(2000);
            loading = false;
        }
    }
}
