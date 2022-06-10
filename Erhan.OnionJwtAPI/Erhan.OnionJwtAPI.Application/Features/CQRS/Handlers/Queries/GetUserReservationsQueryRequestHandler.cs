using AutoMapper;
using Erhan.MovieTicketSystem.Application.Dto.ReservationDtos;
using Erhan.MovieTicketSystem.Application.Features.CQRS.Queries;
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

namespace Erhan.MovieTicketSystem.Application.Features.CQRS.Handlers.Queries
{
    public class GetUserReservationsQueryRequestHandler : IRequestHandler<GetUserReservationsQueryRequest, List<GetAllUserReservationsDto>>
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public GetUserReservationsQueryRequestHandler(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetAllUserReservationsDto>> Handle(GetUserReservationsQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllUserReservationsDto> dto = new List<GetAllUserReservationsDto>();

            try
            {
                List<Reservation> userReservations = await _uow
                                                           .GetRepository<Reservation>()
                                                           .GetAllAsync(x => x.AppUserId == request.UserId);

                foreach (var reservation in userReservations)
                {
                    Chair chair = await _uow.GetRepository<Chair>().FindAsync(reservation.ChairId);
                    Hall hall = await _uow.GetRepository<Hall>().FindAsync(chair.HallId);

                    MovieHall mh = await _uow.GetRepository<MovieHall>()
                                                    .GetByFilterAsync(x => (x.HallId == hall.Id &&
                                                                            x.MovieDate == reservation.ReservationDate));

                    Movie movie = await _uow.GetRepository<Movie>().FindAsync(mh.MovieId);

                    dto.Add(new GetAllUserReservationsDto
                    {
                        AppUserId = reservation.AppUserId,
                        ChairId = reservation.ChairId,
                        Id = reservation.Id,
                        HallName = hall.Hallname,
                        MovieName = movie.Name,
                        ReservationDate = reservation.ReservationDate,
                    });

                    return dto;
                }
            }
            catch (Exception)
            {
                return dto;
            }

            return dto;
        }
    }
}
