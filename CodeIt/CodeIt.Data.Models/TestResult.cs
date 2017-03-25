using System;

using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class TestResult : IEntity
    {
        public Guid Id { get; set; }

        public bool IsPassed { get; set; }

        public Guid SubmissionId { get; set; }

        public Submission Submission { get; set; }
    }
}
