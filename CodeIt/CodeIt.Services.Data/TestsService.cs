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

            this.testsRepository = testsRepository;
            this.efData = efData;
            this.mapper = mapper;
        }

        public void DeleteById(string id)
        {
            var idAsGuid = Guid.Parse(id);
            var test = this.testsRepository.GetById(idAsGuid);
            if (test == null)
            {
                throw new ArgumentException($"Test with id = {idAsGuid} is not found!");
            }

            using (this.efData)
            {
                this.testsRepository.Delete(test);
                this.efData.Commit();
            }
        }

        public IEnumerable<TDestination> GetByChallenge<TDestination>(string challengeId)
        {
            var challengeIdGuid = Guid.Parse(challengeId);
            var allTests = this.mapper.ProjectTo<Test, TDestination>(this.testsRepository.All.Where(x => x.ChallengeId == challengeIdGuid));
            return allTests;
        }

        public void Update(string id, string input, string output)
        {
            var idAsGuid = Guid.Parse(id);
            var test = this.testsRepository.GetById(idAsGuid);
            if (test == null)
            {
                throw new ArgumentException($"Test with id = {idAsGuid} is not found!");
            }

            using (this.efData)
            {
                test.Input = input;
                test.Output = output;
                test.Challenge = test.Challenge;

                this.testsRepository.Update(test);
                this.efData.Commit();
            }
        }
    }
}
