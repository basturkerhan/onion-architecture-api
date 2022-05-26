using AutoMapper;
using Erhan.MovieTicketSystem.Application.Enums;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Commands;
using Erhan.MovieTicketSystem.Application.Interfaces;
using Erhan.MovieTicketSystem.Application.Responses;
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
    public class UpdateHallCommandRequestHandler : IRequestHandler<UpdateHallCommandRequest, Response>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public UpdateHallCommandRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateHallCommandRequest request, CancellationToken cancellationToken)
        {
            Hall unchangedEntity = await _uow.GetRepository<Hall>().FindAsync(request.Id);
            if (unchangedEntity != null)
            {
                _uow.GetRepository<Hall>().Update(_mapper.Map<Hall>(request), unchangedEntity);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success, "Güncelleme işlemi başarılı");
            }

            return new Response(ResponseType.NotFound,"Aradığınız kayıt bulunamadı");
        }
    }
}
