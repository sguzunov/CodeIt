using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CodeIt.Data.Models.Constants;

namespace CodeIt.Data.Models
{
    [ComplexType]
    public class ChallengeProblem
    {
        [Column("Language")]
        public Language Language { get; set; }

        [Column("Description")]
        [MinLength(ValidationConstants.ChallengeDescriptionMinLenght)]
        public string Description { get; set; }

        // TODO: Add Tests
    }
}
