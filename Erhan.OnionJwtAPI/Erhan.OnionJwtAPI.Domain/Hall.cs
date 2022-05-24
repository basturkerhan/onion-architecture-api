using Erhan.MovieTicketSystem.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Domain
{
    public class Hall : BaseEntity
    {
        public string Hallname { get; set; }
        public List<MovieHall> MovieHalls { get; set; }
        public List<Chair> Chairs { get; set; }
    }
}
