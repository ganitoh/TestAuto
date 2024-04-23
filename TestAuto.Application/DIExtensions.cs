using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TestAuto.Application.CQRS;
using TestAuto.Application.CQRS.Behaviors;
using TestAuto.Application.CQRS.Drinks.Commands.CreateDrink;
using TestAuto.Application.CQRS.Drinks.Commands.DeleteDrink;
using TestAuto.Application.CQRS.Drinks.Commands.UpdateDrink;

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
        }

    }
}
