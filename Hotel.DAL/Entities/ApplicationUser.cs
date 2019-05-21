using Microsoft.AspNet.Identity.EntityFramework;

namespace Hotel.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
