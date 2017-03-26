using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Infrastructure.Caching;

namespace CodeIt.Web.Areas.Api.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITracksService tracks;
        private readonly ICacheService cache;

        public TrackController(ITracksService tracks, ICacheService cache)
        {
            Guard.WhenArgument(tracks, nameof(tracks)).IsNull().Throw();
            Guard.WhenArgument(cache, nameof(cache)).IsNull().Throw();

            this.tracks = tracks;
            this.cache = cache;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = this.cache.Get("tracks", () => this.tracks.GetAll().Select(x => new { Id = x.Id, Track = x.Name }), 2 * 60 * 60);
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}