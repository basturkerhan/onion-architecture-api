using Erhan.MovieTicketSystem.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Domain
{
    public class MovieHall : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int HallId { get; set; }
        public Hall Hall { get; set; }

        public DateTime MovieDate { get; set; }
    }
}
