﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
//using FluentValidation;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                        
            return services;
        }
    }
}
