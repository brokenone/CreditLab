using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Logging
{
    public static class LoggingExtensions
    {
        public static IServiceCollection AddAppLogger(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));
            return services;
        }
    }
}
