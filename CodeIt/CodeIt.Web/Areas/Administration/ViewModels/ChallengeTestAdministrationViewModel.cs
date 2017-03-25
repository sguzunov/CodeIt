using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;
using System;

namespace CodeIt.Web.Areas.Administration.ViewModels
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