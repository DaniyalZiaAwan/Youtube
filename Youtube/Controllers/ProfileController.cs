using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Youtube.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult AddVideo()
        {
            return View();
        }
    }
}