using ExamCountdown.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using NavigationHelper;

namespace ExamCountdown.Components
{
    public partial class AppBarButtonComponent
    {
        [Inject]
        public INavigationService NavigationService { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;


        private AppBarButtonModel? model = null;

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += LocationChanged;
            GetIcon();
        }

        private void LocationChanged(object? sender, LocationChangedEventArgs e)
        {
            GetIcon();
            StateHasChanged();
        }

        public void GetIcon()
        {
            if(NavigationService.RelativeUri == "")
            {
                model = new AppBarButtonModel("add", "/add");
                return;
            }

            model = null;
        }

        private void Navigate()
        {
            NavigationService.NavigateTo(model!.Link);
        }
    }
}
