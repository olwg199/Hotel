using Hotel.BLL.DTO;
using Hotel.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        UserDto Get(string id);

        Task<OperationDetails> Registration(UserDto userDto);

        Task<ClaimsIdentity> Login(string userName, string password);

    }
}
