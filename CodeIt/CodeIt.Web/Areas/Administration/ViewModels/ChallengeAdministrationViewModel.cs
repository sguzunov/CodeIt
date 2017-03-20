using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

using CodeIt.Common.Constants;
using CodeIt.Data.Models;
using System.Web.Mvc;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class ChallengeAdministrationViewModel
    {
        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }
        
        public string Track { get; set; }

        public IEnumerable<SelectListItem> Tracks { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        public HttpPostedFileBase FileDescription { get; set; }

        public IEnumerable<ChallengeTestAdministrationViewModel> Tests { get; set; }
    }
}