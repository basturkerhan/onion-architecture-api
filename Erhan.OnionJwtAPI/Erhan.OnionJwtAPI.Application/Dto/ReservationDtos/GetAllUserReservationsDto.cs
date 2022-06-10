using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Dto.ReservationDtos
{
    public class GetAllUserReservationsDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ChairId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string HallName { get; set; }
        public string MovieName { get; set; }
    }
}
