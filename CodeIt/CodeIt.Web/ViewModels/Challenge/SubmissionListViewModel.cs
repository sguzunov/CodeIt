using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;

namespace CodeIt.Web.ViewModels.Challenge
{
    public class SubmissionListViewModel : IMapFrom<Submission>
    {
        public Guid Id { get; set; }

        public string ChallengeTitle { get; set; }

        public bool IsRun { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<TestResultViewModel> Results { get; set; }
    }
}