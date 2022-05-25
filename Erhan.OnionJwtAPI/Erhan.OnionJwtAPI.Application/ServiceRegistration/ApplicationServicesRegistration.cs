using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.AppUserDtos;
using Erhan.MovieTicketSystem.Application.Dto.MovieDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Mappings;
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
            serviceCollection.AddTransient<IValidator<UpdateGenreCommandRequest>, UpdateGenreCommandValidator>();
            serviceCollection.AddTransient<IValidator<CreateGenreCommandRequest>, CreateGenreCommandValidator>();
            serviceCollection.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            serviceCollection.AddTransient<IValidator<UpdateMovieCommandRequest>, UpdateMovieCommandValidator>();
            serviceCollection.AddTransient<IValidator<CreateMovieCommandRequest>, CreateMovieCommandValidator>();
            serviceCollection.AddTransient<IValidator<LoginAppUserQueryRequest>, LoginAppUserQueryValidator>();
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            serviceCollection.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>()
                {
                    new MovieProfile()
                });
            });

        }
    }
}
