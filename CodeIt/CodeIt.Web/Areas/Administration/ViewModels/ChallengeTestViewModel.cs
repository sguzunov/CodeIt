using System.ComponentModel.DataAnnotations;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class ChallengeTestViewModel
    {
        [Required]
        public string Input { get; set; }

        [Required]
        public string Result { get; set; }
    }
}