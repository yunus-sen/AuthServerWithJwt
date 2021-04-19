using AuthServerWithJwt.Core.DTOs;
using AuthServerWithJwt.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Core.Services
{
    public interface IUserService
    {

        Task<Response<UserAppDto>> CreateUserAsyn(UserAppDto userAppDto);
        Task<Response<UserAppDto>> GetUserByUsername(string username);
    }
}
