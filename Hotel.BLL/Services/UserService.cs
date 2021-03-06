﻿using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using Hotel.BLL.Interfaces;
using Hotel.DomainEntities.Identity;
using Hotel.DomainEntities.Identity.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hotel.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationUserManager _userManager;
        private readonly IMapper _mapper;

        public UserService() { }

        public UserService(ApplicationUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public UserDto Get(string id)
        {
            return _mapper.Map<UserDto>(_userManager.FindById(id));
        }

        public async Task<OperationDetails> Registration(UserDto userDto)
        {
            ApplicationUser user = await _userManager.FindAsync(userDto.UserName, userDto.Password);
            if (user == null)
            {
                user = _mapper.Map<UserDto, ApplicationUser>(userDto);
                user.Id = Guid.NewGuid().ToString();

                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Count() != 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }

                await _userManager.AddToRoleAsync(user.Id, "User");

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
