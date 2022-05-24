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
        public bool IsSuitable { get; set; } = true;
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
