using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Youtube.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [NotMapped]
        public string EmbedUrl { get; set; }
        public VideoType Type { get; set; }

        public DateTime DateTime { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public void CreateEmbedUrl()
        {
            EmbedUrl = Url.Substring(0, Url.IndexOf("watch"))
                        + "embed/" + Url.Substring(Url.IndexOf("=") + 1);
        }
    }
}