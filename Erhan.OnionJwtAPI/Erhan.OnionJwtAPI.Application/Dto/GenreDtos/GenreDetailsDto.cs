using Erhan.MovieTicketSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Dto.GenreDtos
{
    public class GenreDetailsDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
    }
}
