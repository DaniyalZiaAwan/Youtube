using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Youtube.Models;

namespace Youtube.ViewModels
{
    public class VideoViewModel
    {
        [Required, StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required, StringLength(255)]
        public string Url { get; set; }

        public VideoType Type { get; set; }
    }
}