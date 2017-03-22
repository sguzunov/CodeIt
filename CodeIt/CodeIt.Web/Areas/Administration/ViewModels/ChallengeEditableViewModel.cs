using System.ComponentModel.DataAnnotations;

using CodeIt.Common.Attributes;
using CodeIt.Common.Constants;
using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class ChallengeEditableViewModel : IMapFrom<Challenge>
    {
        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Track")]
        public string TrackName { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }

        //[Display(Name = "Upload file description (optional)")]
        //public HttpPostedFileBase FileDescription { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        [Display(Name = "Time limit in ms")]
        [MinValue(ValidationConstants.MinimumMemoryInKb)]
        public int TimeLimitInMs { get; set; }

        [Required]
        [Display(Name = "Memory (MB)")]
        [MinValue(ValidationConstants.MinimumMemoryInKb)]
        public int MemoryInMb { get; set; }
    }
}