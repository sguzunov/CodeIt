using System.Web.Mvc;
using System.Linq;
using Bytes2you.Validation;

using System.Web.Hosting;

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
using CodeIt.Web.Infrastructure.FileSystem;

namespace CodeIt.Web.Areas.Administration.Controllers
{
    public class ChallengeController : AdministrationController
    {
        private const string FileDescriptionSystemPath = "/Files/ChallengesDescription/";

        private readonly ITracksService tracks;
        private readonly IChallengesService challenges;
        private readonly IMappingProvider mapper;
        private readonly IFileSystemService fileSystem;
        private readonly IFileUnits fileUtils;

        public ChallengeController(
            ITracksService tracks,
            IChallengesService challenges,
            IFileSystemService fileSystem,
            IMappingProvider mapper,
            IFileUnits fileUtils)
        {
            Guard.WhenArgument(tracks, nameof(tracks)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();
            Guard.WhenArgument(challenges, nameof(challenges)).IsNull().Throw();
            Guard.WhenArgument(fileSystem, nameof(fileSystem)).IsNull().Throw();
            Guard.WhenArgument(fileUtils, nameof(fileUtils)).IsNull().Throw();

            this.tracks = tracks;
            this.mapper = mapper;
            this.challenges = challenges;
            this.fileSystem = fileSystem;
            this.fileUtils = fileUtils;
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
                string fileName = this.fileUtils.ExtractFileName(file.FileName);
                string fileExtension = this.fileUtils.ExtractFileExtension(file.FileName);

                var dbChallenge = this.challenges.CreateWithFileDescription(challenge.Title, challenge.Description, challenge.CategoryId, challenge.Language, challenge.TimeLimitInMs, challenge.MemoryInMb, tests, fileName, fileExtension, FileDescriptionSystemPath);
                await this.fileSystem.SaveFileAsync(FileDescriptionSystemPath + dbChallenge.FileDecription.FileName + "." + fileExtension, file.InputStream);
            }

            return this.Redirect("/");
        }
    }
}