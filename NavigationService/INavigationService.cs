namespace NavigationHelper
{
    public interface INavigationService
    {
        string BaseUri { get; }
        NavigationParameters Parameters { get; }
        string RelativeUri { get; }
        string Uri { get; }

        void NavigateBack();
        void NavigateTo(string url, NavigationParameters? parameters = null);
    }
}