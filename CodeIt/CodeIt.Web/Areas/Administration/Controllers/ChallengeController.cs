using System.Web.Mvc;
using System.Linq;
using Bytes2you.Validation;

using CodeIt.Data.Models;
using CodeIt.Services.Data.Contracts;
using CodeIt.Web.Areas.Administration.ViewModels;
using CodeIt.Services.Logic;
using System.Collections;
using System.Collections.Generic;
using CodeIt.Services.Logic.Contracts;
using System.Threading.Tasks;
using System;
using System.IO;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class ChallengeController : AdministrationController
    {
        private const string FileDescriptionSystemPath = "/Files/ChallengesDescription/";

        private readonly ITracksService tracks;
        private readonly IChallengesService challenges;
        private readonly IMappingProvider mapper;
        private readonly IFileSystemService fileSystem;

        public ChallengeController(ITracksService tracks, IChallengesService challenges, IFileSystemService fileSystem, IMappingProvider mapper)
        {
            Guard.WhenArgument(tracks, nameof(tracks)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(challenges, nameof(challenges)).IsNull().Throw();
            Guard.WhenArgument(fileSystem, nameof(fileSystem)).IsNull().Throw();

            this.tracks = tracks;
            this.mapper = mapper;
            this.challenges = challenges;
            this.fileSystem = fileSystem;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var allTracks = this.tracks.GetAll();
            var viewModel = new CreateChallengeViewModel
            {
                Tracks = new SelectList(allTracks, nameof(Track.Id), nameof(Track.Name))
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ChallengeAdministrationViewModel challenge)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(new CreateChallengeViewModel() { Challenge = challenge, Tracks = new SelectList(new[] { new SelectListItem() }) });
            }

            var tests = this.mapper.MapObject<IEnumerable<ChallengeTestAdministrationViewModel>, IEnumerable<Test>>(challenge.Tests);
            var file = challenge.FileDescription;

            if (file == null)
            {
                this.challenges.Create(challenge.Title, challenge.Description, challenge.CategoryId, challenge.Language, challenge.TimeLimitInMs, challenge.MemoryInMb, tests);
            }
            else
            {
                var dbChallenge = this.challenges.CreateWithFileDescription(challenge.Title, challenge.Description, challenge.CategoryId, challenge.Language, challenge.TimeLimitInMs, challenge.MemoryInMb, tests, file.FileName, "exe", FileDescriptionSystemPath);
                //await this.fileSystem.SaveFileAsync(this.Server.MapPath(FileDescriptionSystemPath), file.InputStream);
            }

            return this.Redirect("/");
        }
    }
}