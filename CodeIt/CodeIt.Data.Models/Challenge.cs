﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CodeIt.Common.Constants;
using CodeIt.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeIt.Data.Models
{
    public class Challenge : IEntity
    {
        private ICollection<Test> tests;

        public Challenge()
        {
            this.tests = new HashSet<Test>();
        }

        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }

        public Language Language { get; set; }

        [Required]
        public int TimeInMs { get; set; }

        [Required]
        public int MemoryInKb { get; set; }

        [Required]
        public string Description { get; set; }

        public FileDecription FileDecription { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [Required]
        public virtual ICollection<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }
    }
}
