using System;
using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class Test : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public string Output { get; set; }

        public Guid ChallengeId { get; set; }

        public Challenge Challenge { get; set; }
    }
}
