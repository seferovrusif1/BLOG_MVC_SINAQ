using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1d.Helpers;

namespace WebApplication1d.Controllers
{
    public class AuthController : Controller
    {
        RoleManager<IdentityRole> _roleManager { get; }

        public AuthController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<bool> CreateRoles()
        {
            foreach (var item in Enum.GetValues(typeof(Role)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = item.ToString()
                    });
                    if (!result.Succeeded)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
