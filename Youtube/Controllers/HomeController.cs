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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var videos = _context.Videos.Include(v => v.User).ToList();
            foreach (var video in videos)
                video.CreateEmbedUrl();

            return View(new HomeIndexVm
            {
                Videos = videos
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}