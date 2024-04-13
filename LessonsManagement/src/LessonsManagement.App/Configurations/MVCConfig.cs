using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace LessonsManagement.App.Configurations
{
    public static class MVCConfig
    {
        public static IServiceCollection AddMVCConfiguration(this IServiceCollection services)
        {
            services.AddMvc(
                o =>
                {
                    //o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "preenche ai pow");
                }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            return services;
        }
    }
}
