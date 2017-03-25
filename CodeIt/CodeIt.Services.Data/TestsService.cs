using Bytes2you.Validation;
using CodeIt.Data.Contracts;
using CodeIt.Data.Models;
using CodeIt.Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeIt.Services.Data.Contracts
{
    public class TestsService : ITestsService
    {
        private readonly IEfRepository<Test> testsRepository;
        private readonly IEfData efData;
        private readonly IMappingProvider mapper;

        public TestsService(IEfRepository<Test> testsRepository, IEfData efData, IMappingProvider mapper)
        {
            Guard.WhenArgument(testsRepository, nameof(testsRepository)).IsNull().Throw();
            Guard.WhenArgument(efData, nameof(efData)).IsNull().Throw();
            Guard.WhenArgument(mapper, nameof(mapper)).IsNull().Throw();

            this.testsRepository = testsRepository;
            this.efData = efData;
            this.mapper = mapper;
        }

        public void DeleteById(Guid id)
        {
            var test = this.GetTestById(id);

            using (this.efData)
            {
                this.testsRepository.Delete(test);
                this.efData.Commit();
            }
        }

        public IEnumerable<TDestination> GetByChallenge<TDestination>(Guid challengeId)
        {
            var allTests = this.mapper.ProjectTo<Test, TDestination>(this.testsRepository.All.Where(x => x.ChallengeId == challengeId));
            return allTests;
        }

        public void Update(Guid id, string input, string output)
        {
            var test = this.GetTestById(id);
            using (this.efData)
            {
                test.Input = input;
                test.Output = output;
                test.Challenge = test.Challenge;

                this.testsRepository.Update(test);
                this.efData.Commit();
            }
        }

        private Test GetTestById(Guid id)
        {
            var test = this.testsRepository.GetById(id);
            if (test == null)
            {
                throw new ArgumentException($"Test with id = {id} is not found!");
            }

            return test;
        }
    }
}
