using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1d.Areas.Admin.ViewModels.Slider;
using WebApplication1d.Contexts;

namespace WebApplication1d.Areas.Admin.Controllers.Slider
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        BlogDbContext _db { get; }

        public SliderController(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _db.Sliders.Select(d => new SliderListItemVM
            {
                Id = d.Id,
                Description = d.Description,
                Rate = d.Rate
            }).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            WebApplication1d.Models.Slider slide = new WebApplication1d.Models.Slider
            {
                Description = vm.Description,
                Rate = vm.Rate
            };
            await _db.Sliders.AddAsync(slide);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            var data = await _db.Sliders.FindAsync(id);

            return View(new SliderUpdateVM
            {
                Description = data.Description,
                Rate = data.Rate
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, SliderUpdateVM vm)
        {
            if (id == null || id <= 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _db.Sliders.FindAsync(id);
            data.Description = vm.Description;
            data.Rate = vm.Rate;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var data = await _db.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            _db.Sliders.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}