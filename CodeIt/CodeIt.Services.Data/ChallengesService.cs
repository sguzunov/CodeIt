using System;
using System.Collections.Generic;

using Bytes2you.Validation;

using CodeIt.Data.Models;
using CodeIt.Data.Contracts;
using CodeIt.Services.Data.Contracts;
using CodeIt.Services.Logic;

namespace CodeIt.Services.Data
{
    public class ChallengesService : IChallengesService
    {
        private readonly IEfRepository<Challenge> challengesRepository;
        private readonly IEfRepository<Test> testsRepository;
        private readonly IEfRepository<Category> categoriesRepository;
        private readonly IEfRepository<FileDecription> fileDescriptionRepository;
        private readonly IEfData efData;
        private readonly IMappingProvider mapper;

        public ChallengesService(
            IEfRepository<Challenge> challengesRepository,
            IEfRepository<Test> testsRepository,
            IEfRepository<FileDecription> fileDescriptionRepository,
            IEfRepository<Category> categoriesRepository, IEfData efData,
            IMappingProvider mapper)
        {
            Guard.WhenArgument(challengesRepository, nameof(challengesRepository)).IsNull().Throw();
            Guard.WhenArgument(testsRepository, nameof(testsRepository)).IsNull().Throw();
            Guard.WhenArgument(categoriesRepository, nameof(categoriesRepository)).IsNull().Throw();
            Guard.WhenArgument(fileDescriptionRepository, nameof(fileDescriptionRepository)).IsNull().Throw();
            Guard.WhenArgument(efData, nameof(efData)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.challengesRepository = challengesRepository;
            this.testsRepository = testsRepository;
            this.categoriesRepository = categoriesRepository;
            this.fileDescriptionRepository = fileDescriptionRepository;
            this.efData = efData;
            this.mapper = mapper;
        }

        public Challenge Create(
            string title,
            string description,
            string categoryId,
            Language language,
            double timeInMs,
            double memoryInMb,
            IEnumerable<Test> tests)
        {
            var category = this.categoriesRepository.GetById(Guid.Parse(categoryId));
            if (category == null)
            {
                throw new ArgumentException("Category id does not match any category!", nameof(categoryId));
            }

            Challenge challenge;
            using (this.efData)
            {
                challenge = new Challenge
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Description = description,
                    Language = language,
                    CategoryId = category.Id,
                    Category = category
                };
                this.challengesRepository.Add(challenge);
                this.AddChallengeTests(tests, challenge);

                this.efData.Commit();
            }

            return challenge;
        }

        public Challenge CreateWithFileDescription(
            string title,
            string description,
            string categoryId,
            Language language,
            double timeInMs,
            double memoryInMb,
            IEnumerable<Test> tests,
            string fileOriginalName,
            string fileExtension,
            string filePath)
        {
            var challenge = this.Create(title, description, categoryId, language, timeInMs, memoryInMb, tests);
            if (challenge != null)
            {
                using (this.efData)
                {
                    var fileInfo = new FileDecription
                    {
                        Id = Guid.NewGuid(),
                        FileName = fileOriginalName + challenge.Id,
                        FileExtension = fileExtension,
                        FileSystemPath = filePath,
                        ChallengeId = challenge.Id,
                    };
                    this.fileDescriptionRepository.Add(fileInfo);
                    challenge.FileDecription = fileInfo;
                    this.efData.Commit();
                }
            }

            return challenge;
        }

        public IEnumerable<TDestination> GetAll<TDestination>()
        {
            var allChallenges = this.mapper.ProjectTo<Challenge, TDestination>(this.challengesRepository.All);
            return allChallenges;
        }

        private void AddChallengeTests(IEnumerable<Test> tests, Challenge challenge)
        {
            foreach (var test in tests)
            {
                test.Id = Guid.NewGuid();
                test.ChallengeId = challenge.Id;
                test.Challenge = challenge;
                this.testsRepository.Add(test);
            }
        }
    }
}
