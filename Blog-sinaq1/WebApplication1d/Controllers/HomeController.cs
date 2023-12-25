using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1d.Contexts;
using WebApplication1d.Models;
using WebApplication1d.ViewModels.SliderVM;

namespace WebApplication1d.Controllers
{
	public class HomeController : Controller
	{
		
		BlogDbContext _db { get; }

        public HomeController(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
		{
			var data = await _db.Sliders.Select(x=>new UserSlider
			{
				Description = x.Description,
				Rate = x.Rate
			}).ToListAsync();
			return View(data);
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}