using CodeIt.Common.Constants;
using CodeIt.Data.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

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

        //public Guid TrackId { get; set; }

        //[Required]
        //public Track Track { get; set; }
    }
}
