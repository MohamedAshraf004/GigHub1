using GigHub.ViewModels;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public GigsController()
        {
            _Context = new ApplicationDbContext();

        }
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var ViewModel = new GigFormViewModel()
            {
                Genres = _Context.Genres.ToList()
            };
            return View(ViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (GigFormViewModel ViewModel)
        {
            //var ArtistId = User.Identity.GetUserId();
            //var artist = _Context.Users.Single(u => u.Id==ArtistId);
            //var genre = _Context.Genres.Single(g => g.Id == ViewModel.Genre);
            if (!ModelState.IsValid)
            {
                ViewModel.Genres = _Context.Genres.ToList();
                return View("Create", ViewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = ViewModel.GetDateTime(),
                GenreId =ViewModel.Genre,
                Venue=ViewModel.Venue

            };

            _Context.Gigs.Add(gig);
            _Context.SaveChanges();
            return RedirectToAction("Index", "Home");


        }
    }
}