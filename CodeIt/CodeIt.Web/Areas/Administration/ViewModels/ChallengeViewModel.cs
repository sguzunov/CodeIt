﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

using CodeIt.Common.Constants;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class ChallengeViewModel
    {
        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }

        public string Category { get; set; }

        public string Track { get; set; }

        public int Language { get; set; }

        [MinLength(ValidationConstants.ChallengeDescriptionMinLength)]
        public string Description { get; set; }

        public HttpPostedFileBase FileDescription { get; set; }

        public IEnumerable<ChallengeTestViewModel> Tests { get; set; }
    }
}