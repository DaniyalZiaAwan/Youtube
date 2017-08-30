using System.Data.Entity.ModelConfiguration;
using Youtube.Models;

namespace Youtube.Configuration
{
    public class VideoConfig : EntityTypeConfiguration<Video>
    {
        public VideoConfig()
        {
            Property(v => v.Title).IsRequired().HasMaxLength(255);
            Property(v => v.UserId).IsRequired();
            Property(v => v.Url).IsRequired().HasMaxLength(255);
        }
    }
}