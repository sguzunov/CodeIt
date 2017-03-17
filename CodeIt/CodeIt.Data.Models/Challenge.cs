using CodeIt.Data.Models.Constants;
using System.ComponentModel.DataAnnotations;

namespace CodeIt.Data.Models
{
    public class Challenge
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
