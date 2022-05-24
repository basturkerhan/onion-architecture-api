using Erhan.MovieTicketSystem.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Domain
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Actors { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<MovieHall> MovieHalls { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
