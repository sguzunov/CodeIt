using CodeIt.Services.Data.Contracts;
using System;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using Bytes2you.Validation;
using CodeIt.Services.Logic.Contracts;
using System.Collections.Generic;
using CodeIt.Services.Logic;
using System.Linq;

namespace CodeIt.Services.Data
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly IEfRepository<Submission> submissionRepository;
        private readonly IEfRepository<Challenge> challengeRepository;
        private readonly IEfData efData;
        private readonly ITimeProvider timeProvider;
        private readonly IMappingProvider mapper;

        public SubmissionsService(
            IEfRepository<Submission> submissionRepository,
            IEfRepository<Challenge> challengeRepository,
            IEfData efData,
            ITimeProvider timeProvider,
            IMappingProvider mapper)
        {
            Guard.WhenArgument(submissionRepository, nameof(submissionRepository)).IsNull().Throw();
            Guard.WhenArgument(challengeRepository, nameof(challengeRepository)).IsNull().Throw();
            Guard.WhenArgument(efData, nameof(efData)).IsNull().Throw();
            Guard.WhenArgument(timeProvider, nameof(timeProvider)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.submissionRepository = submissionRepository;
            this.challengeRepository = challengeRepository;
            this.efData = efData;
            this.timeProvider = timeProvider;
            this.mapper = mapper;
        }

        public Submission Create(User creator, Guid challengeId, string sourceCode)
        {
            Guard.WhenArgument(creator, nameof(creator)).IsNull().Throw();

            var challenge = this.challengeRepository.GetById(challengeId);
            if (challenge == null)
            {
                throw new ArgumentException($"Challenge with id = {challengeId} is not found!");
            }

            var submission = new Submission
            {
                Id = Guid.NewGuid(),
                CreatedOn = this.timeProvider.UtcNow,
                SourceCode = sourceCode,
                ChallengeId = challenge.Id,
                Challenge = challenge,
                User = creator
            };

            using (this.efData)
            {
                this.submissionRepository.Add(submission);
                this.efData.Commit();
            }

            return submission;
        }

        public IEnumerable<TDestination> GetUserSubmissionByChallenge<TDestination>(string userId, string challengeTitle)
        {
            var result = this.mapper.ProjectTo<Submission, TDestination>(
                this.submissionRepository
                .All
                .Where(x => x.User.Id == userId && x.Challenge.Title == challengeTitle)
                .OrderByDescending(x => x.CreatedOn));

            return result;
        }

        public void RunSubmission(Guid id)
        {
            using (this.efData)
            {
                var submission = this.submissionRepository.GetById(id);
                submission.IsRun = true;

                this.submissionRepository.Update(submission);
                this.efData.Commit();
            }
        }
    }
}
