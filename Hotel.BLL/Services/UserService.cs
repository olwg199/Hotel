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
using System.Data.Entity.Validation;

namespace Hotel.BLL.Services
{
    public class UserService : IUserService
    {
        private ApplicationUserManager _userManager;
        private IMapper _mapper;

        public UserService() { }

        public UserService(ApplicationUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<OperationDetails> Registration(UserDTO userDto)
        {
            ApplicationUser user = await _userManager.FindAsync(userDto.UserName, userDto.Password);
            if (user == null)
            {
                user = _mapper.Map<UserDTO, ApplicationUser>(userDto);

                try
                {
                    var result = await _userManager.CreateAsync(user, userDto.Password);

                    if (result.Errors.Count() != 0)
                    {
                        return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                    }
                }
                catch(DbEntityValidationException e)
                {

                }
                catch (Exception ex)
                {

                }


                //await _userManager.AddToRoleAsync(user.Id, userDto.Role);

                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким ником уже существует", "");
            }
        }

        public async Task<ClaimsIdentity> Login(string userName, string password)
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
