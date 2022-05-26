using Erhan.MovieTicketSystem.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Domain
{
    public class Chair : BaseEntity
    {
        public bool IsSuitable { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
