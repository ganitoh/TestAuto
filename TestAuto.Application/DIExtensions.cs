using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestAuto.Application.CQRS;
using TestAuto.Application.CQRS.Behaviors;
using TestAuto.Application.Services.Abstraction;
using TestAuto.Application.Services.Emplementation;

namespace TestAuto.Application
{
    public static class DIExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddAutoMapper(typeof(CQRSMapProfile));

            services.AddScoped<IAccountService, AccountService>();
        }

    }
}
