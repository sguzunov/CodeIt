using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

using CodeIt.Common.Constants;
using CodeIt.Data.Models;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class ChallengeAdministrationViewModel
    {
        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Track { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        [Display(Description = "Description")]
        public HttpPostedFileBase FileDescription { get; set; }

        public IEnumerable<ChallengeTestAdministrationViewModel> Tests { get; set; }
    }
}