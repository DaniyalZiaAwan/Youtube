using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youtube.Models;
using Youtube.ViewModels;

namespace Youtube.Controllers
{
    public class VideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideosController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Single(int id)
        {
            var video = _context.Videos.Include(v => v.User)
                                       .SingleOrDefault(v => v.Id == id);
            video.CreateEmbedUrl();

            if (video == null)
                HttpNotFound("Vide Not Found");

            var viewModel = new VideoSingleVm { Video = video };
            return View(viewModel);
        }
    }
}