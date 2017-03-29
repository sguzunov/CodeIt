using System;
using System.Collections.Generic;

using CodeIt.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.Data.Models
{
    public class Submission : IEntity, IAuditInfo
    {
        private ICollection<TestResult> results;

        public Submission()
        {
            this.results = new HashSet<TestResult>();
        }

        public Guid Id { get; set; }

        [Required]
        public string SourceCode { get; set; }

        [Required]
        public User User { get; set; }

        public bool IsRun { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public Guid ChallengeId { get; set; }

        [Required]
        public Challenge Challenge { get; set; }

        public virtual ICollection<TestResult> Results { get; set; }
    }
}
