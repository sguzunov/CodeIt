using Bytes2you.Validation;
using CodeIt.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public JsonResult ByTrackId(string trackId)
        {
            var categories = this.tracks.GetCategoriesByTrackId(Guid.Parse(trackId));
            return this.Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}