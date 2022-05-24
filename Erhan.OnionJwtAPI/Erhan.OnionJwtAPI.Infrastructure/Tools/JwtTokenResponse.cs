using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Infrastructure.Tools
{
    public class JwtTokenResponse
    {
        public JwtTokenResponse(DateTime expireDate, string token)
        {
            ExpireDate = expireDate;
            Token = token;
        }
        public DateTime ExpireDate { get; set; }
        public string Token { get; set; }
    }
}
