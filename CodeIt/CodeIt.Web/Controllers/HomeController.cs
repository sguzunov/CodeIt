using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Web.ViewModels.Home;
using System;
using System.Web.Mvc;

namespace CodeIt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITracksService tracks;
        private readonly ICategoriesService categories;
        private readonly IMappingProvider mapper;

        public HomeController(ITracksService tracks, ICategoriesService categories, IMappingProvider mapper)
        {
            this.tracks = tracks;
            this.categories = categories;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        [OutputCache(CacheProfile = "Dashboard")]
        public ActionResult Tracks()
        {
            var result = this.tracks.GetAll<TrackViewModel>();
            return this.View(result);
        }

        public ActionResult CategoriesByTrack(string track)
        {
            var categories = this.categories.GetByTrack<CategoryViewModel>(track);

            return this.View(categories);
        }
    }
}