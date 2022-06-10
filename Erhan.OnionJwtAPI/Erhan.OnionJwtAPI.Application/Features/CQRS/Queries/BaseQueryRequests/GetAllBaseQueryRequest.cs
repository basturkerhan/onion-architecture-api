using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Queries.BaseQueryRequests
{
    public class GetAllBaseQueryRequest<T> : IRequest<List<T>>
    {
    }
}
