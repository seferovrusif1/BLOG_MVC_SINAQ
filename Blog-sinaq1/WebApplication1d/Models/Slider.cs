using System.ComponentModel.DataAnnotations;

namespace WebApplication1d.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(0,4)]

        public int Rate { get; set; }
    }
}
