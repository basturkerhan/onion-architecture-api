using AutoMapper;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Commands
{
    public class CreateMovieCommandRequestHandler : IRequestHandler<CreateMovieCommandRequest>
    {
        private readonly IRepository<Movie> _repository;
        private readonly IMapper _mapper;

        public CreateMovieCommandRequestHandler(IRepository<Movie> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Movie
            {
                Actors = request.Actors,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                ReleaseDate = DateTime.UtcNow,
            });

            return Unit.Value;
        }
    }
}
