using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class Category : IEntity
    {
        private ICollection<Challenge> challenges;

        public Category()
        {
            this.challenges = new HashSet<Challenge>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid TrackId { get; set; }

        public Track Track { get; set; }

        public ICollection<Challenge> Challenges
        {
            get { return this.challenges; }
            set { this.challenges = value; }
        }
    }
}
