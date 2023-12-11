using DiabeticsSystem.BlazorUI.Features.Home.Data.Model;
using DiabeticsSystem.BlazorUI.Features.Home.Domain.Usecase;
using Microsoft.AspNetCore.Components;

namespace DiabeticsSystem.BlazorUI.Features.Home.Presentation.Logic
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private IHomeUsecase Usecase { get; set; } = default!;

        public HomeAnalyticsVM homeAnalyticsVM = new();

        public bool Overlay = false;

        protected override async Task OnInitializedAsync()
        {
            Overlay = true;
            await FetchItemsAsync();
            Overlay = false;
        }

        public async Task FetchItemsAsync()
        {
            homeAnalyticsVM = await Usecase.GetHomeAnalytics();
        }
    }
}
