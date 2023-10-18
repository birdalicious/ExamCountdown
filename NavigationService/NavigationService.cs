using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationHelper
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationManager _navigationManager;
        public NavigationParameters Parameters { get; private set; }

        private NavigationStack _stack;

        public string BaseUri => _navigationManager.BaseUri;
        public string Uri => _navigationManager.Uri;
        public string RelativeUri => _navigationManager.ToBaseRelativePath(_navigationManager.Uri);

        public NavigationService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _stack = new();

            Parameters = new NavigationParameters();
        }

        public void NavigateTo(string url, NavigationParameters? parameters = null)
        {
            _stack.Add(Uri, Parameters);

            InternalNavigateTo(url, parameters);
        }

        public void NavigateBack()
        {
            (var uri, var parameters) = _stack.Pop();

            InternalNavigateTo(uri, parameters);
        }

        private void InternalNavigateTo(string uri, NavigationParameters? parameters = null)
        {
            Parameters = parameters ?? new NavigationParameters();
            _navigationManager.NavigateTo(uri);
        }
    }
}
