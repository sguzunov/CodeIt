using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CodeIt.Data.Models.Constants;

namespace CodeIt.Data.Models
{
    public class Track
    {
        private ICollection<Category> categories;
        private ICollection<Challenge> challenges;

        public Track()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.NamesMinLenght)]
        [MaxLength(ValidationConstants.NamesMaxLenght)]
        public string Name { get; set; }
        
        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Challenge> Challenges
        {
            get { return this.challenges; }
            set { this.challenges = value; }
        }

        [NotMapped]
        public int ChallengesCount => this.Challenges.Count;
    }
}
