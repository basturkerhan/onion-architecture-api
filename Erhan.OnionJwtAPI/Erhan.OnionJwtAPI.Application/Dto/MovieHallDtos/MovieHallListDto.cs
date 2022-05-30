using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Dto.MovieHallDtos
{
    public class MovieHallListDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime MovieDate { get; set; }
    }
}
