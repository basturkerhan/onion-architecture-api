using Erhan.MovieTicketSystem.Application.Dto.AppUserDtos;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.ValidationRules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.ServiceRegistration
{
    static public class ApplicationServicesRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
