using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Dto
{
    public class CheckUserResponseDto
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public int Id { get; set; }
        public bool IsExist { get; set; }
    }
}
