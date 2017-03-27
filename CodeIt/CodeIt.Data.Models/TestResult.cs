using System;

using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class TestResult : IEntity
    {
        public Guid Id { get; set; }

        public SphereApiTestIdentifier ApiIdentifier { get; set; }

        public bool IsEvaluated { get; set; }

        public Guid SubmissionId { get; set; }

        public Submission Submission { get; set; }

        public Guid TestId { get; set; }

        public Test Test { get; set; }
    }
}
