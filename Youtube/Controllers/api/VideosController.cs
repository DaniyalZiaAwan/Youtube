using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Http;
using Youtube.Dtos;
using Youtube.Models;

namespace Youtube.Controllers.api
{
    [Authorize]
    public class VideosController : ApiController
    {
        private readonly ApplicationDbContext _db;
        public VideosController()
        {
            _db = new ApplicationDbContext();
        }

        [HttpPost]
        [Route("api/videos/AddLikeAndDislike")]
        public IHttpActionResult AddLikeAndDislike([FromBody]LikeDislikeDto data)
        {
            var myId = User.Identity.GetUserId(); 

            if (data.Op.Equals("like"))
            {
                if (data.SecondOp.Equals("add"))
                {
                    var like = new Like(myId, data.VideoId);
                    _db.Likes.Add(like);
                }
                else
                {
                    var likeInDb = _db.Likes.SingleOrDefault(l => l.UserId == myId
                                            && l.VideoId == data.VideoId);
                    _db.Likes.Remove(likeInDb);
                }
            }
            else
            {
                if (data.SecondOp.Equals("add"))
                {
                    var dislike = new Dislike(myId, data.VideoId);
                    _db.Dislikes.Add(dislike);
                }
                else
                {
                    var dislikeInDb = _db.Dislikes.SingleOrDefault(l => l.UserId == myId
                                           && l.VideoId == data.VideoId);
                    _db.Dislikes.Remove(dislikeInDb);
                }
            }

            _db.SaveChanges();
            return Ok();
        }
    }
}
