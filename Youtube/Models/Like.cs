namespace Youtube.Models
{
    public class Like : LikeDislikeBase
    {
        public Like(string myId, int videoId)
            :base(myId, videoId)
        {

        }

        public Like()
        {

        }
    }
}