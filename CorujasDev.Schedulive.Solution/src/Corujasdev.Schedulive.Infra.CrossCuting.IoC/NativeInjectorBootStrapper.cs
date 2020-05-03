using CorujasDev.Schedule.Infra.Data.Context;
using CorujasDev.Schedule.Infra.Data.Repositories;
using CorujasDev.Schedule.Infra.Data.UoW;
using CorujasDev.Schedulive.Application.Interfaces;
using CorujasDev.Schedulive.Application.Service;
using CorujasDev.Schedulive.Core.Data;
using CorujasDev.Schedulive.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Corujasdev.Schedulive.Infra.CrossCuting.IoC
{
    public static class NativeInjectorBootStrapper
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ScheduliveContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IUserService, UserService>();
        }
    }
}
