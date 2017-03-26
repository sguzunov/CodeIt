using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;
using CodeIt.Web.ViewModels.Home;
using System.Web.Mvc;

namespace CodeIt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITracksService tracks;
        private readonly IMappingProvider mapper;

        public HomeController(ITracksService tracks, IMappingProvider mapper)
        {
            this.tracks = tracks;
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
    }
}