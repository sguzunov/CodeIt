using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CodeIt.Data.Models.Constants;
using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class Track : IEntity
    {
        private ICollection<Category> categories;
        private ICollection<Challenge> challenges;

        public Track()
        {
            this.categories = new HashSet<Category>();
            this.challenges = new HashSet<Challenge>();
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
