using System;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Infrastructure.Caching;

namespace CodeIt.Web.Areas.Api.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ITracksService tracks;
        private readonly ICacheService cache;

        public CategoryController(ITracksService tracks, ICacheService cache)
        {
            Guard.WhenArgument(tracks, nameof(tracks)).IsNull().Throw();
            Guard.WhenArgument(cache, nameof(cache)).IsNull().Throw();

            this.tracks = tracks;
            this.cache = cache;
        }

        [HttpGet]
        public JsonResult ByTrackId(string id)
        {
            var categories = this.cache.Get(
                "categories",
                () => this.tracks.GetCategoriesByTrackId(Guid.Parse(id)).Select(x => new { Id = x.Id, Category = x.Name }).ToList(),
                2 * 60 * 60);

            return this.Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}