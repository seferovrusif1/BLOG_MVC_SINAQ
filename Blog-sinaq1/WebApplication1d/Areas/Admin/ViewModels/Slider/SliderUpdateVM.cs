﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1d.Areas.Admin.ViewModels.Slider
{
    public class SliderUpdateVM
    {
        [Required]
        public string Description { get; set; }
        [Required, Range(0, 4)]

        public int Rate { get; set; }
    }
}
