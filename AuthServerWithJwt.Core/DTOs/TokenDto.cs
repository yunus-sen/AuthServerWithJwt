using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Core.DTOs
{
    public class TokenDto
    {
        public string  AccessToken { get; set; }
        public DateTime AccessTokenExpiteion { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiteion { get; set; }
    }
}
