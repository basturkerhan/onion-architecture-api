using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Infrastructure.Tools
{
    public class JwtTokenSettings
    {
        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "erhanerhanerhan1";
        public const int Expire = 30;
    }
}
