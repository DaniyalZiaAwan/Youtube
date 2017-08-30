﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Youtube.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public VideoType Type { get; set; }

        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
    }
}