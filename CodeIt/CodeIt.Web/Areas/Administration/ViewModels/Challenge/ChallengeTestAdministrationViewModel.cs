using System;
using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;

namespace CodeIt.Web.Areas.Administration.ViewModels.Challenge
{
    public class ChallengeTestAdministrationViewModel : IMapTo<Test>, IMapFrom<Test>
    {
        // [Required]
        // public bool IsSample { get; set; }

        public Guid Id { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public string Output { get; set; }
    }
}