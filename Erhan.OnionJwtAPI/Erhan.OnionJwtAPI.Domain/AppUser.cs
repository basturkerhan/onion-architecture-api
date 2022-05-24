using Erhan.MovieTicketSystem.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Domain
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
