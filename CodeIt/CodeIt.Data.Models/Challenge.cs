using System;
using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models.Contracts;
using CodeIt.Common.Constants;

namespace CodeIt.Data.Models
{
    public class Challenge : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }

        public Language Language { get; set; }

        public ChallengeDecription ChallengeDecription { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        public int TrackId { get; set; }

        [Required]
        public Track Track { get; set; }
    }
}
