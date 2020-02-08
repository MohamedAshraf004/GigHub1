using GigHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _Context;
        public HomeController()
        {
            _Context = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
            var ViewAllUpcomingGigs = _Context.Gigs
                .Include(g => g.Artist)
                .Include(g =>g.Genre)
                .Where(g => g.DateTime > DateTime.Now);
            return View(ViewAllUpcomingGigs);
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