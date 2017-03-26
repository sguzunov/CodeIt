using CodeIt.Services.Data.Contracts;
using System;
using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using Bytes2you.Validation;
using CodeIt.Services.Logic.Contracts;

namespace CodeIt.Services.Data
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly IEfRepository<Submission> submissionRepository;
        private readonly IEfRepository<Challenge> challengeRepository;
        private readonly IEfData efData;
        private readonly ITimeProvider timeProvider;

        public SubmissionsService(
            IEfRepository<Submission> submissionRepository,
            IEfRepository<Challenge> challengeRepository,
            IEfData efData, ITimeProvider timeProvider)
        {
            Guard.WhenArgument(submissionRepository, nameof(submissionRepository)).IsNull().Throw();
            Guard.WhenArgument(challengeRepository, nameof(challengeRepository)).IsNull().Throw();
            Guard.WhenArgument(efData, nameof(efData)).IsNull().Throw();
            Guard.WhenArgument(timeProvider, nameof(timeProvider)).IsNull().Throw();

            this.submissionRepository = submissionRepository;
            this.challengeRepository = challengeRepository;
            this.efData = efData;
            this.timeProvider = timeProvider;
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
    }
}
