using System;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using CodeIt.Services.Data.Contracts;

namespace CodeIt.Web.Areas.Api.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ITracksService tracks;

        public CategoryController(ITracksService tracks)
        {
            Guard.WhenArgument(tracks, nameof(tracks)).IsNull().Throw();

            this.tracks = tracks;
        }

        [HttpGet]
        public JsonResult ByTrackId(string id)
        {
            var categories = this.tracks.GetCategoriesByTrackId(Guid.Parse(id)).Select(x => new { Id = x.Id, Category = x.Name }).ToList();
            return this.Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}