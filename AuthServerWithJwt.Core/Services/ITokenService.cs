using AuthServerWithJwt.Core.Configuration;
using AuthServerWithJwt.Core.DTOs;
using AuthServerWithJwt.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Core.Services
{
    public interface ITokenService
    {
        TokenDto CreatedToken(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
