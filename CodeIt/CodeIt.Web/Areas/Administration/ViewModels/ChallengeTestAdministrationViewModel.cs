using System.ComponentModel.DataAnnotations;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class ChallengeTestAdministrationViewModel
    {
        // [Required]
        // public bool IsSample { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public string Output { get; set; }
    }
}