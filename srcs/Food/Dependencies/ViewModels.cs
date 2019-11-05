using Food.ViewModels.Recipes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Dependencies
{
    public static class ViewModels
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddScoped<IGridViewModel, GridViewModel>();

            return services;
        }
    }
}
