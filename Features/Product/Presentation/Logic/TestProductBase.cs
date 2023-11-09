using DiabeticsSystem.BlazorUI.Features.Product.Domain.Entitiy;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Product.Presentation.Logic
{
    public class TestProductBase : ComponentBase
    {
        [Inject]
        private HttpClient? Http { get; set; }
        //[Inject]
        //private NavigationManager? Nav { get; set; }

        public bool _clearItems = false;

        [Parameter]
        public IQueryable<ProductVM>? Items { get; set; }

        public PaginationState pagination = new() { ItemsPerPage = 10 };

        public string nameFilter = string.Empty;

        public int N = 0;

        public IQueryable<ProductVM>? Filtereditems =>
            Items!.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

        protected override async Task OnInitializedAsync()
        {
            Items = (await Http!.GetFromJsonAsync<List<ProductVM>>("api/Product/GetAllProducts"))!.AsQueryable();
        }

        public void HandleCountryFilter(ChangeEventArgs args)
        {
            if (args.Value is string value)
            {
                nameFilter = value;
            }
        }

        public void HandleClear()
        {
            if (string.IsNullOrWhiteSpace(nameFilter))
            {
                nameFilter = string.Empty;
            }
        }

        public async Task ToggleItemsAsync()
        {
            if (_clearItems)
            {
                Items = null;
            }
            else
            {
                Items = (await Http!.GetFromJsonAsync<List<ProductVM>>("api/Product/GetAllProducts"))!.AsQueryable();
            }
        }
    }
}