using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

using CodeIt.Common.Attributes;
using CodeIt.Common.Constants;
using CodeIt.Data.Models;

namespace CodeIt.Web.Areas.Administration.ViewModels.Challenge
{
    public class ChallengeAdministrationViewModel
    {
        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Track")]
        public string TrackId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryId { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Upload file description (optional)")]
        public HttpPostedFileBase FileDescription { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        [Display(Name = "Time limit in ms")]
        [MinValue(ValidationConstants.MinimumMemoryInKb)]
        public int TimeLimitInMs { get; set; }

        [Required]
        [Display(Name = "Memory (KB)")]
        [MinValue(ValidationConstants.MinimumMemoryInKb)]
        public int MemoryInKb { get; set; }

        [Required]
        public IEnumerable<ChallengeTestAdministrationViewModel> Tests { get; set; }
    }
}
