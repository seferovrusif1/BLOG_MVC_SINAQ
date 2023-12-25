using Microsoft.AspNetCore.Identity;

namespace WebApplication1d.Models
{
    public class AppUser:IdentityUser
    {
        public string fulname { get; set; }
    }
}
