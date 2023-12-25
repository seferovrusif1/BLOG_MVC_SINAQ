using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1d.Areas.Admin.ViewModels;
using WebApplication1d.Areas.Admin.ViewModels.Setting;
using WebApplication1d.Contexts;

namespace WebApplication1d.Areas.Admin.Controllers.SliderIMG
{
    [Area("Admin")]
    public class SliderIMGController : Controller
    {
        BlogDbContext _db { get; }

        public SliderIMGController(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Sliders.Select(d => new SettingItemVM
            {
                id = d.Id,
            }).ToListAsync();
            return View(data);
        }
       
    }
}
