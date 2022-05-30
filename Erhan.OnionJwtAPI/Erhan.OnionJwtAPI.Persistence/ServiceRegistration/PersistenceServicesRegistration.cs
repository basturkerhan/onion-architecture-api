using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Persistence.Repositories;
using Erhan.MovieTicketSystem.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Erhan.MovieTicketSystem.Persistence.ServiceRegistration
{
    public static class PersistenceServicesRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddScoped<IUow, Uow>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

    }
}
