using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using CodeIt.Services.Data.Contracts;

namespace CodeIt.Web.Areas.Api.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITracksService tracks;

        public TrackController(ITracksService tracks)
        {
            Guard.WhenArgument(tracks, nameof(tracks)).IsNull().Throw();

            this.tracks = tracks;
        }

        public JsonResult GetAll()
        {
            var result = this.tracks.GetAll().Select(x => new { Id = x.Id, Track = x.Name });
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}