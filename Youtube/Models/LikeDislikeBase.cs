using System;

namespace Youtube.Models
{
    public abstract class LikeDislikeBase
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Video Video { get; set; }
        public int VideoId { get; set; }

        public DateTime DateTime { get; set; }

        public LikeDislikeBase(string myId, int videoId)
        {
            UserId = myId;
            VideoId = videoId;
            DateTime = DateTime.Now;
        }

        public LikeDislikeBase()
        {

        }
    }
}