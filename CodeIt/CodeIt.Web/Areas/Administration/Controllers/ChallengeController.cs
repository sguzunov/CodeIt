using System;
using System.Web.Mvc;

using Bytes2you.Validation;

using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Areas.Administration.ViewModels;
using System.Web;
using System.Linq;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class ChallengeController : AdministrationController
    {
        private readonly ITracksService tracks;

        public ChallengeController(ITracksService tracks)
        {
            Guard.WhenArgument(tracks, nameof(tracks)).IsNull().Throw();

            this.tracks = tracks;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var allTracks = this.tracks.GetAll();
            var viewModel = new CreateChallengeViewModel
            {
                Tracks = new SelectList(allTracks, nameof(Track.Id), nameof(Track.Name))
            };

            var cate = this.tracks.GetCategoriesByTrackId(allTracks.First().Id);

            return this.View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(ChallengeAdministrationViewModel challenge)
        {
            throw new NotImplementedException();
        }
    }
}