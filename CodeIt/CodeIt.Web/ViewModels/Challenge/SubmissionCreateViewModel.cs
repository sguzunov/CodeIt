using System.ComponentModel.DataAnnotations;

namespace CodeIt.Web.ViewModels.Challenge
{
    public class SubmissionCreateViewModel
    {
        [Required]
        public string ChallengeId { get; set; }

        [Required]
        public string SourceCode { get; set; }
    }
}