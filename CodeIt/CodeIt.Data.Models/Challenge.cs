using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models.Constants;
using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class Challenge : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLenght)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLenght)]
        public string Title { get; set; }

        public ChallengeProblem Problem { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        public int TrackId { get; set; }

        [Required]
        public Track Track { get; set; }
    }
}
