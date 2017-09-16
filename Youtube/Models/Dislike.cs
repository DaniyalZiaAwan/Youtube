namespace Youtube.Models
{
    public class Dislike : LikeDislikeBase
    {
        public Dislike(string myId, int videoId)
            : base(myId, videoId)
        {

        }

        public Dislike()
        {

        }
    }
}