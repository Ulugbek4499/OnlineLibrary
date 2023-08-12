using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineLibrary.Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
      /*  services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            option.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            option.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        });*/
       // services.AddScoped<IUserRefreshToken, RefreshToken>();
       // services.AddScoped<IJwtToken, JwtToken>();
        //services.AddScoped<GenericExcelReport>();

        //return services;
    }
}
