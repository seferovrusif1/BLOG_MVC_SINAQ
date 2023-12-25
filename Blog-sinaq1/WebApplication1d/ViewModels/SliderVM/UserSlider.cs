using System.ComponentModel.DataAnnotations;

namespace WebApplication1d.ViewModels.SliderVM
{
    public class UserSlider
    {
        [Required]
        public string Description { get; set; }
        [Required, Range(0, 4)]

        public int Rate { get; set; }
    }
}
