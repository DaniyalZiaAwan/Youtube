using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Youtube.Models;

namespace Youtube.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProfileController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult AddVideo()
        {
            return View();
        }

        public ActionResult VideoGallery()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddVideo(Video video)
        {
            if (!ModelState.IsValid)
                return View(video);

            var myId = User.Identity.GetUserId();
            video.UserId = myId;

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();

            return RedirectToAction("VideoGallery");
        }
    }
}