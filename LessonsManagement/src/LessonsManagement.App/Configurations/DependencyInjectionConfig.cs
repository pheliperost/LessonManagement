using LessonsManagement.App.Extensions;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Notifications;
using LessonsManagement.Business.Services;
using LessonsManagement.Data.Context;
using LessonsManagement.Data.Repository;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace LessonsManagement.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IFileImportedRepository, FileImportedRepository>();
            services.AddScoped<ILessonImportedRepository, LessonImportedRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, MoedaValidationAttributeAdapterProvider>();

            services.AddScoped<INotifyer, Notifyer>();
            services.AddScoped<IStudentService, StudentsService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<ILessonsService, LessonsService>();
            services.AddScoped<ILessonImportedService, LessonImportedService>();
            services.AddScoped<IFileImportedService, FileImportedService>();


            return services;
        }
    }
}
