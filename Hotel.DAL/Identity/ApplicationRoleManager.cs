using Hotel.DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store) { }
    }
}
