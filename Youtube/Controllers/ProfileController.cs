using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Youtube.Models;
using Youtube.ViewModels;

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
        public ActionResult AddVideo(VideoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var myId = User.Identity.GetUserId();

            var video = new Video
            {
                Description = viewModel.Description,
                Title = viewModel.Title,
                Type = viewModel.Type,
                UserId = myId,
                DateTime = DateTime.Now,
                Url = viewModel.Url
            };

            _context.Videos.Add(video);
            _context.SaveChanges();

            return RedirectToAction("VideoGallery");
        }
    }
}