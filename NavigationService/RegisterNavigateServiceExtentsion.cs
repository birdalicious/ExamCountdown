using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationHelper
{
    public static class RegisterNavigateServiceExtentsion
    {
        public static IServiceCollection AddNavigationService(this IServiceCollection services)
        {
            return services.AddSingleton<INavigationService, NavigationService>();
        }
    }
}
