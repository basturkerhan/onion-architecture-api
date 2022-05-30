using Erhan.MovieTicketSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Dto.HallDto
{
    public class HallDetailsDto
    {
        public int Id { get; set; }
        public string Hallname { get; set; }
        public List<MovieHall> MovieHalls { get; set; }
        public List<Chair> Chairs { get; set; }
    }
}
