using ExamCountdown;
using MatBlazor;
using NavigationHelper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Blazored.LocalStorage;

namespace ExamCountdown
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMatBlazor();
            builder.Services.AddRadzenComponents();
            builder.Services.AddNavigationService();
            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}