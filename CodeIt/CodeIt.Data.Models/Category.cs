using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models.Constants;

namespace CodeIt.Data.Models
{
    public class Category
    {
        private ICollection<Challenge> challenges;

        public Category()
        {
            this.challenges = new HashSet<Challenge>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NamesMinLenght)]
        [MaxLength(ValidationConstants.NamesMaxLenght)]
        public string Name { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }

        public ICollection<Challenge> Challenges
        {
            get { return this.challenges; }
            set { this.challenges = value; }
        }
    }
}
