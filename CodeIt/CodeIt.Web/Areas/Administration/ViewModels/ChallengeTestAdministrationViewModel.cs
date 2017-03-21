using System.ComponentModel.DataAnnotations;

using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class ChallengeTestAdministrationViewModel : IMapTo<Test>
    {
        // [Required]
        // public bool IsSample { get; set; }

        [Required]
        public string Input { get; set; }

        [Required]
        public string Output { get; set; }
    }
}