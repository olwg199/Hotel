using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using Hotel.BLL.Interfaces;
using Hotel.DAL.EF;
using Hotel.DAL.Entities;
using Hotel.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace Hotel.BLL.Services
{
    public class UserService : IUserService
    {
        private ApplicationUserManager _userManager;

        public UserService() { }

        public UserService(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await _userManager.FindAsync(userDto.UserName, userDto.Password);

            if (user == null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, ApplicationUser>());
                user = Mapper.Map<UserDTO, ApplicationUser>(userDto);

                var result = await _userManager.CreateAsync(user);

                if(result.Errors.Count() != 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }

                await _userManager.AddToRoleAsync(user.Id, userDto.Role);

                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким ником уже существует", "");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(string userName, string password)
        {
            ClaimsIdentity claim = null;

            ApplicationUser user = await _userManager.FindAsync(userName, password);

            if(user != null)
            {
                claim = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}
