using Microsoft.EntityFrameworkCore;
using WebApplication1d.Contexts;
using WebApplication1d.Models;

namespace WebApplication1d.Helpers
{
    public class SliderIMGService
    {
        BlogDbContext _db { get; }

        public SliderIMGService(BlogDbContext db)
        {
            _db = db;
        }
               public async Task<Setting> GetSettingsAsync()
            => await _db.Settings.FindAsync(1);
    }
}
