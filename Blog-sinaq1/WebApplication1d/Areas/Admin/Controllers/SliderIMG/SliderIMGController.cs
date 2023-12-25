using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1d.Areas.Admin.ViewModels;
using WebApplication1d.Areas.Admin.ViewModels.Setting;
using WebApplication1d.Areas.Admin.ViewModels.Slider;
using WebApplication1d.Contexts;
using WebApplication1d.Helpers;

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
            var data = await _db.Settings.Select(d => new SettingItemVM
            {
                id=d.id,
                ImagePath= d.ImagePath
            }).ToListAsync();
            return View(data);
        }
        public async Task<IActionResult> Update(int? id)
        {
            var data = await _db.Settings.FindAsync(id);

            return View(new SettingUpdateVM
            {
                ImagePathstr=data.ImagePath
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, SettingUpdateVM vm)
        {
            if (id == null || id <= 0) return BadRequest();

            if (vm.ImagePathstr == null) { ModelState.AddModelError("ImagePathstr", "Can not delete image"); };
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (System.IO.File.Exists(Path.Combine(PathConst.roothpath, (string)vm.ImagePathstr)))
            {
                System.IO.File.Delete(Path.Combine(PathConst.roothpath, (string)vm.ImagePathstr));
            }

            var data = await _db.Settings.FindAsync(id);
            data.ImagePath = await vm.ImagePath.fileupload(PathConst.Pathstr);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
