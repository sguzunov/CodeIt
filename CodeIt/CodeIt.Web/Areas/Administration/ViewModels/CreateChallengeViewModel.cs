using System.Web.Mvc;

namespace CodeIt.Web.Areas.Administration.ViewModels
{
    public class CreateChallengeViewModel
    {
        public SelectList Tracks { get; set; }

        public ChallengeAdministrationViewModel Challenge { get; set; }
    }
}