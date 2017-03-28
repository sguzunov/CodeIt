using System;

using CodeIt.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeIt.Data.Models
{
    public class TestResult : IEntity
    {
        public Guid Id { get; set; }

        public SphereApiTestIdentifier ApiIdentifier { get; set; }

        public bool IsEvaluated { get; set; }

        public bool IsPassed { get; set; }

        public bool TimeLimited { get; set; }

        public string RuntimeException { get; set; }

        public string CompileError { get; set; }

        //[NotMapped]
        //public bool HasCompileError => !string.IsNullOrEmpty(this.CompileError);

        //[NotMapped]
        //public bool HasRuntimeException => !string.IsNullOrEmpty(this.RuntimeException);

        public Guid SubmissionId { get; set; }

        public Submission Submission { get; set; }

        public Guid TestId { get; set; }

        public virtual Test Test { get; set; }
    }
}
