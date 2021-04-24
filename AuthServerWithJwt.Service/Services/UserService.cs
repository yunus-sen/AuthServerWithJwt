using AuthServerWithJwt.Core.DTOs;
using AuthServerWithJwt.Core.Models;
using AuthServerWithJwt.Core.Services;
using AuthServerWithJwt.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServerWithJwt.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<UserAppDto>> CreateUserAsyn(CreateUserDto userAppDto)
        {
            var user = new UserApp { Email = userAppDto.Email, UserName = userAppDto.UserName };

            var result = await _userManager.CreateAsync(user, userAppDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<UserAppDto>> GetUserByUsername(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return Response<UserAppDto>.Fail("UserName not found", 404, true);
            }

            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }
    }
}
