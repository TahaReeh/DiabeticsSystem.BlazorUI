using DiabeticsSystem.BlazorUI.Core.Constants;
using DiabeticsSystem.BlazorUI.Features.Product.Domain.Entitiy;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using System.Net.Http.Json;

namespace DiabeticsSystem.BlazorUI.Features.Product.Presentation.Logic
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        private HttpClient? Http { get; set; }
        [Inject]
        private NavigationManager? Nav { get; set; }


        public PaginationState pagination = new() { ItemsPerPage = 10 };

        public bool loading = false;

        public IQueryable<ProductVM>? Items;

        public string nameFilter = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Items = (await Http!.GetFromJsonAsync<List<ProductVM>>("api/Product/GetAllProducts"))!.AsQueryable();
        }
     
        public IQueryable<ProductVM>? Filtereditems =>
            Items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));

        public void HandleNameFilter(ChangeEventArgs args)
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

        public async Task OnCreateClick()
        {
            loading = true;
            await Task.Delay(2000);
            loading = false;
            Nav!.NavigateTo(RouterConst.Home);
        }

        public async Task OnDeleteClick(Guid id)
        {
            loading = true;
            await Task.Delay(2000);
            loading = false;
        }
    }
}
