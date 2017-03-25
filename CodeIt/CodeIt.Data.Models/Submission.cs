﻿using System;
using System.Collections.Generic;

using CodeIt.Data.Models.Contracts;

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

        public string SourceCode { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid ChallengeId { get; set; }

        public Challenge Challenge { get; set; }

        public virtual ICollection<TestResult> Results { get; set; }
    }
}